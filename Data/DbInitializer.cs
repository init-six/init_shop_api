using init_api.Models;

namespace init_api.Data;
public class DbInitializer
{
    public static void Initialize(ShopContext context)
    {
        // Look for any user.
        if (context.Users.Any())
        {
            return;   // DB has been seeded
        }

        var users = new User[]
        {
            new User{UserName= "Enno Huang",Password="123",Role="admin", Email="123@mail.com", TelNumber = 123},
            new User{UserName= "Eval Liu",Password="123",Role="admin", Email="123@mail.com", TelNumber = 123},
            new User{UserName= "Customer X",Password="123",Role="customer", Email="123@mail.com", TelNumber = 123}
        };

        context.Users.AddRange(users);
        context.SaveChanges();

        var products = new Product[]
        {
            new Product(){Name="test",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
    
}