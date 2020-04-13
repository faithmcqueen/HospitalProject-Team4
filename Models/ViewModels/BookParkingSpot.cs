using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalProject_Team4.Models.ViewModels
{
    public class BookParkingSpot
    {
        //Get all information about the parking space that is booked 
        public ParkingSpot ParkingSpot { get; set; }
        public List<ParkingSpot> ParkingSpots { get; set; }
        //Get all of the spot booking information
        public List<SpotBooking> SpotBookings { get; set; }
        public SpotBooking SpotBooking { get; set; }
    }
}