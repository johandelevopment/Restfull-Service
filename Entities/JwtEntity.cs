using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class JwtEntity
    {
        public string JWT_SECRET_KEY { get; set; }
        public string JWT_AUDIENCE_TOKEN { get; set; }
        public string JWT_ISSUER_TOKEN { get; set; }
        public string JWT_EXPIRE_MINUTES { get; set; }
    }
}
