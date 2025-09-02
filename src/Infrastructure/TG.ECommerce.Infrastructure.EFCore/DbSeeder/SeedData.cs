using TG.ECommerce.Domain.AggregateModels.CategoryAggregate;
using TG.ECommerce.Domain.AggregateModels.ProductAggregate;

namespace TG.ECommerce.Infrastructure.EFCore.DbSeeder;

public static class SeedData
{
    public static List<Category> GetCategoriesWithProducts()
    {
        var categories = new List<Category>();

        // Electronics Category
        var electronics = new Category("Electronics");
        electronics.AddProduct(new Product("iPhone 15 Pro", 999, 50, electronics.Id));
        electronics.AddProduct(new Product("Samsung Galaxy S24", 849, 75, electronics.Id));
        electronics.AddProduct(new Product("MacBook Air M3", 1299, 30, electronics.Id));
        electronics.AddProduct(new Product("iPad Pro 12.9", 1099, 25, electronics.Id));
        electronics.AddProduct(new Product("AirPods Pro", 249, 100, electronics.Id));
        electronics.AddProduct(new Product("Sony WH-1000XM5", 399, 60, electronics.Id));
        electronics.AddProduct(new Product("Dell XPS 13", 1199, 20, electronics.Id));
        electronics.AddProduct(new Product("Nintendo Switch", 299, 80, electronics.Id));
        categories.Add(electronics);

        // Clothing Category
        var clothing = new Category("Clothing");
        clothing.AddProduct(new Product("Nike Air Max 90", 120, 150, clothing.Id));
        clothing.AddProduct(new Product("Levi's 501 Jeans", 89, 200, clothing.Id));
        clothing.AddProduct(new Product("Adidas Hoodie", 65, 180, clothing.Id));
        clothing.AddProduct(new Product("Zara White Shirt", 39, 120, clothing.Id));
        clothing.AddProduct(new Product("H&M Cotton T-Shirt", 12, 300, clothing.Id));
        clothing.AddProduct(new Product("Calvin Klein Underwear", 25, 250, clothing.Id));
        clothing.AddProduct(new Product("Nike Running Shorts", 35, 100, clothing.Id));
        clothing.AddProduct(new Product("Tommy Hilfiger Polo", 79, 90, clothing.Id));
        categories.Add(clothing);

        // Home & Living Category
        var homeLiving = new Category("Home & Living");
        homeLiving.AddProduct(new Product("Dyson V15 Vacuum", 749, 40, homeLiving.Id));
        homeLiving.AddProduct(new Product("KitchenAid Stand Mixer", 449, 25, homeLiving.Id));
        homeLiving.AddProduct(new Product("Philips Coffee Machine", 299, 50, homeLiving.Id));
        homeLiving.AddProduct(new Product("IKEA Office Chair", 159, 80, homeLiving.Id));
        homeLiving.AddProduct(new Product("Instant Pot Duo", 99, 70, homeLiving.Id));
        homeLiving.AddProduct(new Product("Roomba i7+", 599, 30, homeLiving.Id));
        homeLiving.AddProduct(new Product("Nest Thermostat", 249, 45, homeLiving.Id));
        homeLiving.AddProduct(new Product("Philips Hue Bulbs", 49, 120, homeLiving.Id));
        categories.Add(homeLiving);

        // Sports & Outdoors Category
        var sports = new Category("Sports & Outdoors");
        sports.AddProduct(new Product("Yoga Mat Premium", 29, 200, sports.Id));
        sports.AddProduct(new Product("Dumbell Set 20kg", 149, 60, sports.Id));
        sports.AddProduct(new Product("Treadmill Pro 3000", 1299, 15, sports.Id));
        sports.AddProduct(new Product("Tennis Racket Wilson", 89, 40, sports.Id));
        sports.AddProduct(new Product("Mountain Bike 27.5", 599, 25, sports.Id));
        sports.AddProduct(new Product("Basketball Official", 35, 100, sports.Id));
        sports.AddProduct(new Product("Running Shoes Brooks", 129, 80, sports.Id));
        sports.AddProduct(new Product("Camping Tent 4P", 199, 30, sports.Id));
        categories.Add(sports);

        // Books Category
        var books = new Category("Books");
        books.AddProduct(new Product("Clean Code", 45, 100, books.Id));
        books.AddProduct(new Product("Design Patterns", 59, 75, books.Id));
        books.AddProduct(new Product("The Pragmatic Programmer", 49, 90, books.Id));
        books.AddProduct(new Product("You Don't Know JS", 39, 120, books.Id));
        books.AddProduct(new Product("Refactoring", 54, 60, books.Id));
        books.AddProduct(new Product("Code Complete", 49, 80, books.Id));
        books.AddProduct(new Product("Clean Architecture", 44, 70, books.Id));
        books.AddProduct(new Product("Effective C#", 52, 50, books.Id));
        categories.Add(books);

        // Beauty & Health Category
        var beauty = new Category("Beauty & Health");
        beauty.AddProduct(new Product("Vitamin D3 Supplement", 19, 300, beauty.Id));
        beauty.AddProduct(new Product("Face Moisturizer SPF 30", 25, 150, beauty.Id));
        beauty.AddProduct(new Product("Electric Toothbrush", 89, 80, beauty.Id));
        beauty.AddProduct(new Product("Hair Straightener", 79, 60, beauty.Id));
        beauty.AddProduct(new Product("Protein Powder 2kg", 49, 100, beauty.Id));
        beauty.AddProduct(new Product("Essential Oil Set", 35, 120, beauty.Id));
        beauty.AddProduct(new Product("Face Cleanser", 18, 200, beauty.Id));
        categories.Add(beauty);

        // Automotive Category
        var automotive = new Category("Automotive");
        automotive.AddProduct(new Product("Car Phone Mount", 25, 150, automotive.Id));
        automotive.AddProduct(new Product("Dash Camera 4K", 149, 40, automotive.Id));
        automotive.AddProduct(new Product("Car Vacuum Cleaner", 79, 60, automotive.Id));
        automotive.AddProduct(new Product("Jump Starter 12V", 99, 30, automotive.Id));
        automotive.AddProduct(new Product("Car Air Freshener", 8, 300, automotive.Id));
        automotive.AddProduct(new Product("Tire Pressure Gauge", 15, 200, automotive.Id));
        automotive.AddProduct(new Product("Car Cover Waterproof", 45, 50, automotive.Id));
        categories.Add(automotive);

        // Toys & Games Category
        var toys = new Category("Toys & Games");
        toys.AddProduct(new Product("LEGO Creator Expert", 199, 40, toys.Id));
        toys.AddProduct(new Product("PlayStation 5 Controller", 69, 80, toys.Id));
        toys.AddProduct(new Product("Monopoly Board Game", 29, 100, toys.Id));
        toys.AddProduct(new Product("Rubik's Cube 3x3", 12, 200, toys.Id));
        toys.AddProduct(new Product("Chess Set Wooden", 39, 60, toys.Id));
        toys.AddProduct(new Product("Remote Control Car", 89, 50, toys.Id));
        toys.AddProduct(new Product("Puzzle 1000 Pieces", 19, 80, toys.Id));
        categories.Add(toys);

        return categories;
    }
}