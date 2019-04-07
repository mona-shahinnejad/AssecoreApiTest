using AssecoreApiTest.Common.Enums;
using CsvHelper;
using CsvHelper.Configuration;

namespace AssecoreApiTest.Business.Dto
{
    public class UserCsvMap : ClassMap<UserDto>
    {
        public UserCsvMap()
        {
            Map(m => m.Id).Ignore();
            Map(m => m.LastName).Index(0);
            Map(m => m.FirstName).Index(1);
            Map(m => m.ZipCode).ConvertUsing(row => int.Parse((row as CsvReader)?.GetField(2).Split(' ')[0]));
            Map(m => m.City).ConvertUsing(row => (row as CsvReader)?.GetField(2).Split(' ')[1]);
            Map(m => m.Color).ConvertUsing(row => (Colors)int.Parse(((row as CsvReader)?.GetField(3))));
        }
    }
}
