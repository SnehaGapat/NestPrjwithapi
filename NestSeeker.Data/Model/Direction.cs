using System;
using System.Collections.Generic;
using System.Text;

namespace NestSeeker.Data.Model
{
    public class Direction
    {
        public int Id { get; set; }
        public IList<Property> Property { get; set; }
    }
}
