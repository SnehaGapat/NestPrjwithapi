using System;
using System.Collections.Generic;
using System.Text;

namespace NestSeeker.Data.Model
{
    public class TransactionType
    {
        public int Id { get; set; }
        public IList<Requests> Request { get; set; }
    }
}
