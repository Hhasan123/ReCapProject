using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDto:IDto
    {
        public int RentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
