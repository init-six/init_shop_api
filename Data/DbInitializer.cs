using init_api.Entities;

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

        var categories =new Category[]
        {
            new Category(){UUID=Guid.Parse("3953f186-91a8-414d-9ca5-b155277db662"),Name="Living Room Decoration"},
            new Category(){UUID=Guid.Parse("5bc184a0-8e2e-4699-b36a-113c9556fe6a"),Name="Dining Room Decoration"},
            new Category(){UUID=Guid.Parse("406a14e7-94f1-4a92-885a-e68c16fcb1e5"),Name="Kitchen Decoration"},
            new Category(){UUID=Guid.Parse("f62fbe3a-20f7-4937-8636-d15f6de282e4"),Name="Bath Room Decoration"},
            new Category(){UUID=Guid.Parse("787ca403-bdeb-48ed-9353-53f351c9f231"),Name="Bedroom Decoration"},
            new Category(){UUID=Guid.Parse("5edafdf6-d289-4fa0-85b4-fa251171f771"),Name="Garden Decoration"},
            new Category(){UUID=Guid.Parse("c60b08b2-99da-4be6-9346-0f53a771bde6"),Name="Car Decoration"},
        };

        context.Categories.AddRange(categories);
        context.SaveChanges();

        var products = new Product[]
        {
            new Product(){UUID=Guid.Parse("e7405060-1da1-4499-9861-db3f1504ff1e"),FkCategoryId=1,CategoryId=Guid.Parse("3953f186-91a8-414d-9ca5-b155277db662"),Name="living room dec 1",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"}, 
            new Product(){UUID=Guid.Parse("318a1b5e-47b1-42c6-9619-625d9a57cf1c"),FkCategoryId=1,CategoryId=Guid.Parse("3953f186-91a8-414d-9ca5-b155277db662"),Name="living room dec 2",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("f57f3208-4e84-485a-aa53-76764e1f1e1c"),FkCategoryId=2,CategoryId=Guid.Parse("5bc184a0-8e2e-4699-b36a-113c9556fe6a"),Name="Dining Dec 1",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("ffdae6cc-a77b-467f-aece-82c4532b7899"),FkCategoryId=2,CategoryId=Guid.Parse("5bc184a0-8e2e-4699-b36a-113c9556fe6a"),Name="Dining Dec 2",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("40ede81f-51bc-4af3-9302-2ac71a2245b7"),FkCategoryId=3,CategoryId=Guid.Parse("406a14e7-94f1-4a92-885a-e68c16fcb1e5"),Name="kitchen dec 1",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("eaeaed1f-602c-49b4-987e-9c681a22580b"),FkCategoryId=3,CategoryId=Guid.Parse("406a14e7-94f1-4a92-885a-e68c16fcb1e5"),Name="kitchen dec 2",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("9969d5e9-c5f5-48c0-8cc6-58776b23ca25"),FkCategoryId=4,CategoryId=Guid.Parse("f62fbe3a-20f7-4937-8636-d15f6de282e4"),Name="bath dec 1",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("9455620b-7ba7-4fb5-a314-0f320cf8535a"),FkCategoryId=4,CategoryId=Guid.Parse("f62fbe3a-20f7-4937-8636-d15f6de282e4"),Name="bath dec 2",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("007793fd-ff81-4ec2-9a59-59ebbf1c321f"),FkCategoryId=4,CategoryId=Guid.Parse("f62fbe3a-20f7-4937-8636-d15f6de282e4"),Name="bath dec 3",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("73881aa4-4ddf-49bc-9994-85f447782696"),FkCategoryId=4,CategoryId=Guid.Parse("f62fbe3a-20f7-4937-8636-d15f6de282e4"),Name="bath dec 4",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("7199c569-08b4-44f2-b22e-630b1332d5f3"),FkCategoryId=5,CategoryId=Guid.Parse("787ca403-bdeb-48ed-9353-53f351c9f231"),Name="bed dec 1",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("ae9c992e-ed3f-457e-ae3e-dfdc0b1bfc21"),FkCategoryId=5,CategoryId=Guid.Parse("787ca403-bdeb-48ed-9353-53f351c9f231"),Name="bed dec 2",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("e7721193-ba79-4351-a1cf-19334a00dc0e"),FkCategoryId=5,CategoryId=Guid.Parse("787ca403-bdeb-48ed-9353-53f351c9f231"),Name="bed dec 3",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("8d9fbe21-945f-4e12-b4fb-f1d4c909f496"),FkCategoryId=5,CategoryId=Guid.Parse("787ca403-bdeb-48ed-9353-53f351c9f231"),Name="bed dec 4",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("11c07313-d7e5-471f-aebe-ef431eee887c"),FkCategoryId=5,CategoryId=Guid.Parse("787ca403-bdeb-48ed-9353-53f351c9f231"),Name="bed dec 5",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("c9460a40-3886-4130-84a8-06c725f9053f"),FkCategoryId=6,CategoryId=Guid.Parse("5edafdf6-d289-4fa0-85b4-fa251171f771"),Name="garden dec 1",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("6c1e3ae7-73e8-49bc-a072-dad8e0905144"),FkCategoryId=6,CategoryId=Guid.Parse("5edafdf6-d289-4fa0-85b4-fa251171f771"),Name="garden dec 2",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("f24133f2-b63e-47ca-aa89-2d7af32f72ad"),FkCategoryId=6,CategoryId=Guid.Parse("5edafdf6-d289-4fa0-85b4-fa251171f771"),Name="garden dec 3",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("9f1e15cd-c7b8-4f36-801e-3a0cecb7fddf"),FkCategoryId=6,CategoryId=Guid.Parse("5edafdf6-d289-4fa0-85b4-fa251171f771"),Name="garden dec 4",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("14ee5e31-f1f3-4486-a98d-3e38f95b08d7"),FkCategoryId=7,CategoryId=Guid.Parse("c60b08b2-99da-4be6-9346-0f53a771bde6"),Name="car dec 1",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("3e11ab8f-ccb2-489f-850e-98e749f072f7"),FkCategoryId=7,CategoryId=Guid.Parse("c60b08b2-99da-4be6-9346-0f53a771bde6"),Name="car dec 2",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
            new Product(){UUID=Guid.Parse("b73d427b-ebc6-48a6-ac64-95b37355cc8f"),FkCategoryId=7,CategoryId=Guid.Parse("c60b08b2-99da-4be6-9346-0f53a771bde6"),Name="car dec 3",Description="test",Price=10.05m, Stock = 1, PictureURL = "test"},
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
    
}