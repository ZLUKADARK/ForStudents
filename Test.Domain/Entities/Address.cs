namespace Test.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Home { get; set; }
        public string NumberOfApartment { get; set; }
        public List<Person> Person { get; set; } = new List<Person>();
    }
}
