namespace Portfolio.Domain
{
    public class User : IEntity<string>
    {
        public string Id => $"{FirstName}{LastName}";

        public string FirstName { get; internal set; }

        public string LastName { get; internal set; }

        public string Description { get; internal set; }

        public int Photography { get; internal set; }

        public int WebDesign { get; internal set; }
    }
}
