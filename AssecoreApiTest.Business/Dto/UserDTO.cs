using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssecoreApiTest.Common.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AssecoreApiTest.Business.Dto
{
    public class UserDto
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ZipCode { get; set; }

        public string City { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Colors Color { get; set; }
    }
}
