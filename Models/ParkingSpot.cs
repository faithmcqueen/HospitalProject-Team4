using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalProject_Team4.Models
{
    public class ParkingSpot
    {
        /* A parking spot is something that any user can book for a specific amount of time, and purchases. One parking spot can be booked by many users. 
         * Things that describe a parking spot are:
         * the Lot it is located in
         * The Location of the spot in the lot
         */

        [Key]
        public int SpotID { get; set; }
        public string lot { get; set; }
        public string location { get; set; }
        public string branch { get; set; }
    }
}