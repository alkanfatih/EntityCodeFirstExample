using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EntityCodeFirstExample
{
    public class ETradeContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
