namespace Portfolio.Domain
{
    public class Product : IEntity<string>
    {
        public string Id { get; set; }

        public string ProductName { get; set; }

        public string ProductCode { get; set; }

        public string ReleaseDate { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public string StarRating { get; set; }

        public string ImageUrl { get; set; }
    }
}
