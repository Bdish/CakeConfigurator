using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Unit
    {
        public int Id { get; set; }
        public int IdUnitName { get; set; }
        public int IdUnitType { get; set; }
        public int IdUnitCode { get; set; }
        public int IdUnitOfMeasurement { get; set; }
        public int IdUnitPrice { get; set; }
        public int IdQuantityInUnit { get; set; }
    }
}
