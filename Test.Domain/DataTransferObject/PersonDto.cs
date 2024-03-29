﻿namespace Test.Domain.DataTransferObject
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int SocialClassId { get; set; }
        public List<AddressListDto>? Address { get; set; }
        public SocialClassListDto? SocialClass { get; set; }
    }
}
