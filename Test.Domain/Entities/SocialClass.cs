﻿namespace Test.Domain.Entities
{
    public class SocialClass
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal AverageIncome { get; set; }
        public List<Person> Person { get; set; } = new List<Person>();
    }
}
