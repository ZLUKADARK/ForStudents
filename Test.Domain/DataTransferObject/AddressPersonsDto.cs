namespace Test.Domain.DataTransferObject
{
    public class AddressPersonsDto
    {
        public int AddressId { get; set; }
        public List<int> PersonsId { get; set; }
    }
}
