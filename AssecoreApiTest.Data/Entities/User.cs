using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssecoreApiTest.Common.Enums;

namespace AssecoreApiTest.Data.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ZipCode { get; set; }

        public string City { get; set; }

        public Colors Color { get; set; }
    }
}
