using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EntityCodeFirstExample
{
    public class Product //Tablo Ismi
    {
        [Key] //Özellik Atama
        public int ID { get; set; } //Sütun ismi
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }

    }
}
