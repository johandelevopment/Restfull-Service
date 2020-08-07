using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class ExperienceEntity
    {
        public int UserId { get; set; }
        public string ExperiencePhoto { get; set; }
        public int CountryId { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
