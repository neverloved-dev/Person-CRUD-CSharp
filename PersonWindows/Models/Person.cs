using System;
using System.Collections.Generic;

namespace PersonWindows.Models
{
    public partial class Person
    {
        public short Id { get; set; }
        public decimal Oid { get; set; }
        public string NameAndSurname { get; set; } = null!;
        public string Place { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Mail { get; set; } = null!;
    }
}
