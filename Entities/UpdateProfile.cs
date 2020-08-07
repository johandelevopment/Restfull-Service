using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UpdateProfile
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool PhotoChange { get; set; }
        public string PhotoUser { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string Description { get; set; }
        public string Document { get; set; }
        public string Rh { get; set; }
        public string BornCity { get; set; }
        public string Ocupation { get; set; }
        public string Languages { get; set; }
        public DateTime DateBorn { get; set; }
        public string PassporNumber { get; set; }
        public string PdfDocument { get; set; }
        public string EmergencyName { get; set; }
        public string EmergencyEmail { get; set; }
        public string EmergencyPhone { get; set; }
    }
}
