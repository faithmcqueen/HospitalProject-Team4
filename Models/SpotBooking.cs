using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalProject_Team4.Models
{
    public class SpotBooking
    {
        /* A spot booking is a specific instance of a user booking a ParkingSpot. This will include specific information regarding the booking. One user can make many bookings, but a booking can only have one user. One spot can be booked many times, but a booking can only have one spot. 
         * Things that describe SpotBookings include:
         * UserID
         * SpotID
         * booking date
         * start date
         * end date
         * license plate
         */

        [Key]
        public int SpotBookingID { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Representing the Many in (One Spot to Many SpotBookings)
        public int SpotID { get; set; }
        [ForeignKey("SpotID")]
        public virtual ParkingSpot ParkingSpots { get; set; }

    }
}