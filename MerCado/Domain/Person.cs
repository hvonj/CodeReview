using System;
using System.Collections.Generic;
using System.Text;

namespace MerCado.Domain
{
    public class Person
    {
        public int ID { get; set; }
        public int age { get; set; }
        public Gender gender { get; set; }
        public string location { get; set; }
        public string email { get; set; }
    }

    public enum Gender
    {
        Male, Female, Other
    }
}
