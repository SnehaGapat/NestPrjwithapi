using System;
using System.Collections.Generic;
using System.Text;

namespace NestSeeker.Data.Model
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PropertyId { get; set; } //FK
        public byte[] Value { get; set; }
        public Property Property { get; set; }
        public List<Property> Properties { get; set; }
    }
}
