using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int Id { get; set; }
        public short BrandId { get; set; }
        public short ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public short ColorId { get; set; }
        public string Name { get; set; }
    }
}