using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class MessagesAboutCar
    {
        public static string CarAdded = "Car successfuly added.";
        public static string CarNameInvalid = "Car name is invalid.";
        public static string CarsListed = "Cars Listed.";
        public static string CarDailyPriceInvalid = "Car daily price must be more than 0.";
        public static string CarUpdated = "Car successfuly updated.";
        public static string CarDeleted = "Car successfuly deleted.";
        public static string CarGetted = "Car successfuly getted";
        public static string CarNotFound = "The car to be delete was not found";
    }
}