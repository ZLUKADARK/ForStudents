﻿namespace Test.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int SocialClassId { get; set; }
        public List<Address> Address { get; set; } = new List<Address>();
        public SocialClass SocialClass { get; set; }
    }
}
