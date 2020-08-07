using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public class DataProfile
    {
        public int UserId { get; set; }
        public string Names { get; set; }
        public string UserName { get; set; }
        public string Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserPhoto { get; set; }
        public string Description { get; set; }
        public string CountryPhoto { get; set; }
        public string CountryDeal { get; set; }
        public List<string> ListPreferences { get; set; }
    }
}
