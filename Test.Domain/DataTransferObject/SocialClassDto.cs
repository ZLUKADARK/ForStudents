namespace Test.Domain.DataTransferObject
{
    public class SocialClassDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal AverageIncome { get; set; }
        public PersonDto Person { get; set; }
    }
}
