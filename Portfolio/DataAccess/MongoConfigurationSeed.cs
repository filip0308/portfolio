using Portfolio.Domain;

namespace Portfolio.DataAccess
{
    public static class MongoConfigurationSeed
    {
        public static void Seed(this IUserRepository userRepository)
        {
            userRepository.Upsert(new Domain.User
            {
                FirstName = "Filip",
                LastName = "Kozhinkov",
                Description = "Some text about me. Some text about me. I am lorem ipsum consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat",
                Photography = 99,
                WebDesign = 60
            });
        }

        public static void Seed(this IProductRepository productRepository)
        {
            foreach (var product in _products)
            {
                productRepository.Upsert(product);
            }
        }

        private static Product[] _products = new[]
        {
            new Product
            {
                Id = "1",
                ProductName= "Leaf Rake",
                ProductCode = "GDN-0011",
                ReleaseDate = "March 19, 2016",
                Description = "Leaf rake with 48-inch wooden handle.",
                Price= "19.95",
                StarRating = "3.2",
                ImageUrl = "https://openclipart.org/image/300px/svg_to_png/26215/Anonymous_Leaf_Rake.png"
            },
            new Product
            {
                Id = "2",
                ProductName= "Garden Cart",
                ProductCode = "GDN-0023",
                ReleaseDate = "March 18, 2016",
                Description = "15 gallon capacity rolling garden cart.",
                Price= "32.99",
                StarRating = "4.2",
                ImageUrl = "https://openclipart.org/image/300px/svg_to_png/58471/garden_cart.png"
            }
        };
    }
}
