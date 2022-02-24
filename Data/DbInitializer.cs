using init_api.Entities;

namespace init_api.Data;
public class DbInitializer
{
    public static void Initialize(ShopContext context)
    {
        // Look for any user.
        //if (context.Users.Any())
        //{
        //    return;   // DB has been seeded
        //}

        //var users = new User[]
        //{
        //    //new User{UserName= "Customer X",Password="123",Role="customer", Email="123@mail.com", TelNumber = 123}
        //};

        //context.Users.AddRange(users);
        //context.SaveChanges();

        //var categories = new Category[]
        //{
        //    new Category(){ParentId=null,IsParent=false,UUID=Guid.Parse("3953f186-91a8-414d-9ca5-b155277db662"),Name="Living Room Decoration"},
        //    new Category(){ParentId=null,IsParent=false,UUID=Guid.Parse("5bc184a0-8e2e-4699-b36a-113c9556fe6a"),Name="Dining Room Decoration"},
        //    new Category(){ParentId=null,IsParent=false,UUID=Guid.Parse("406a14e7-94f1-4a92-885a-e68c16fcb1e5"),Name="Kitchen Decoration"},
        //    new Category(){ParentId=null,IsParent=false,UUID=Guid.Parse("f62fbe3a-20f7-4937-8636-d15f6de282e4"),Name="Bath Room Decoration"},
        //    new Category(){ParentId=null,IsParent=false,UUID=Guid.Parse("787ca403-bdeb-48ed-9353-53f351c9f231"),Name="Bedroom Decoration"},
        //    new Category(){ParentId=null,IsParent=false,UUID=Guid.Parse("5edafdf6-d289-4fa0-85b4-fa251171f771"),Name="Garden Decoration"},
        //    new Category(){ParentId=null,IsParent=false,UUID=Guid.Parse("c60b08b2-99da-4be6-9346-0f53a771bde6"),Name="Car Decoration"},
        //};

        //context.Categories.AddRange(categories);
        //context.SaveChanges();
    }

}
