using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car
    {
        public int Id { get; set; }
        public short BrandId { get; set; }
        public short CarClassId { get; set; }
        public string Title { get; set; }
        public short ModelYear { get; set; }
        public short DailyPrice { get; set; }
        public string Description { get; set; }
        public short ColourId { get; set; }
    }
}
