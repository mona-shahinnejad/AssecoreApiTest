using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AssecoreApiTest.Business.Dto;
using AssecoreApiTest.Business.IService;
using AssecoreApiTest.Common.Enums;
using AssecoreApiTest.Data;
using AssecoreApiTest.Data.Entities;
using AutoMapper;
using Common.Helpers;

namespace AssecoreApiTest.Business.Service
{
    public class UserService : IUserService
    {
        private readonly AssecoreApiTestDatabaseContext _context;
        private readonly IMapper _mapper;

        public UserService(AssecoreApiTestDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UserDto GetPersonById(long id)
        {
            return _mapper.Map<UserDto>(_context.Users.FirstOrDefault(u => u.Id == id));
        }

        public IEnumerable<UserDto> GetPersons()
        {
            return _mapper.Map<IEnumerable<UserDto>>(_context.Users.AsNoTracking().AsEnumerable());
        }

        public IEnumerable<UserDto> GetPersonsByColor(Colors color)
        {
            return _mapper.Map<IEnumerable<UserDto>>(_context.Users.AsNoTracking().Where(u => u.Color == color).AsEnumerable());
        }

        public bool LoadUserDataFromCsv()
        {
            var result = false;

            try
            {
                if (!_context.Users.Any())
                {
                    string rootDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
                    string pathFinalAccessFile = Path.Combine(rootDirectoryPath, "App_Data", ConfigurationReader.ReadAppConfig("CsvData.csv", "CsvData.csv"));

                    using (var textReader = new StreamReader(pathFinalAccessFile))
                    {
                        var users = CsvHelpers.ReadFileWithoutHeader<UserDto>(textReader, typeof(UserCsvMap));

                        if (users != null && users.Any())
                        {
                            _context.Users.AddRange(_mapper.Map<IEnumerable<User>>(users));

                            _context.SaveChanges();

                            result = true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                //Log error
            }

            return result;
        }

        public bool SaveNewPerson(UserDto user)
        {
            var result = false;

            try
            {
                var existUser = _context.Users.FirstOrDefault(u => u.FirstName == user.FirstName
                && u.LastName == user.LastName
                && u.ZipCode == user.ZipCode);

                if (existUser != default(User))
                {
                    existUser = _mapper.Map(user, existUser, opt => opt.BeforeMap((src, des) => src.Id = existUser.Id));
                }
                else
                {
                    _context.Users.Add(_mapper.Map<User>(user));
                }

                _context.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                //Log error
            }

            return result;
        }
    }
}
