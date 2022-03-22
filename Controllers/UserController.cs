using Microsoft.AspNetCore.Mvc;
using init_api.Models;
using init_api.Services;
using init_api.Entities;
using AutoMapper;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
namespace init_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration, IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(UserAddDto request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest();
            }
            if (await _userRepository.UserExistAsync(request.Email))
            {
                return Conflict("User Email Exist");
            }
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User() { };
            user.Email = request.Email.ToLower().Trim();
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.UserName = request.UserName;
            user.UUID = Guid.NewGuid();
            _userRepository.AddUser(user);
            await _userRepository.SaveAsync();
            var returnDto = _mapper.Map<UserDTO>(user);
            return Ok(returnDto);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(UserLoginDto request)
        {
            if (string.IsNullOrEmpty(request.Email))
            {
                return BadRequest();
            }
            if (!await _userRepository.UserExistAsync(request.Email))
            {
                return Conflict("User email not exist");
            }

            var user = await _userRepository.GetUserAsync(request.Email);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            if (string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("please input password");
            }

            if (!VerifyPsswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Passowrd not correct");
            }

            string token = CreateToken(user);
            var returnDto = _mapper.Map<UserDTO>(user);
            returnDto.Token = token;
            return Ok(returnDto);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPsswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }

        [HttpPut("{userUUID}")]
        public async Task<IActionResult> UpdateUser(Guid userUUID, UserUpdateDto userUpdateDto)
        {
            if (!await _userRepository.UserExistAsync(userUUID))
            {
                return NotFound();
            }
            var entity = await _userRepository.GetUserAsync(userUUID);
            if (entity == null)
            {
                return NotFound();
            }
            _mapper.Map(userUpdateDto, entity);
            _userRepository.UpdateUser(entity);
            await _userRepository.SaveAsync();
            return NoContent();
        }
    }
}
