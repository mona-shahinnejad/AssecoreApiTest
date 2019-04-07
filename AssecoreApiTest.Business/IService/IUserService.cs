using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssecoreApiTest.Business.Dto;
using AssecoreApiTest.Common.Enums;

namespace AssecoreApiTest.Business.IService
{
    public interface IUserService
    {
        bool LoadUserDataFromCsv();

        IEnumerable<UserDto> GetPersons();

        UserDto GetPersonById(long Id);

        IEnumerable<UserDto> GetPersonsByColor(Colors color);

        bool SaveNewPerson(UserDto user);
    }
}
