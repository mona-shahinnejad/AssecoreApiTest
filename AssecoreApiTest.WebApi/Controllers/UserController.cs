using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using AssecoreApiTest.Business.Dto;
using AssecoreApiTest.Business.IService;
using AssecoreApiTest.Common.Enums;

namespace AssecoreApiTest.WebApi.Controllers
{
    /// <summary>
    /// APi for person data
    /// </summary>
    [RoutePrefix("api/person")]
    public class UserController : ApiController
    {
        private readonly IUserService _UserService;

        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        /// <summary>
        /// rerturn all Users data
        /// </summary>
        /// <returns>{UserDto}</returns>
        [HttpGet]
        [Route("persons")]
        [ResponseType(typeof(List<UserDto>))]
        public IHttpActionResult GetPersons()
        {
            try
            {
                var result = _UserService.GetPersons();

                if (result != null && result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Return specfic User data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>{UserDto}</returns>
        [HttpGet]
        [Route("persons/{id}")]
        [ResponseType(typeof(UserDto))]
        public IHttpActionResult GetUserById(long id)
        {
            try
            {
                var result = _UserService.GetPersonById(id);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Return persons with specific color
        /// </summary>
        /// <param name="color"></param>
        /// <returns>{UserDto}</returns>
        [HttpGet]
        [Route("persons/color/{color}")]
        [ResponseType(typeof(List<UserDto>))]
        public IHttpActionResult GetPersonsByColor(long color)
        {
            try
            {
                var result = _UserService.GetPersonsByColor((Colors)color);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Update or Save New User
        /// </summary>
        [HttpPost]
        [Route("save")]
        public IHttpActionResult SaveUser(UserDto user)
        {
            try
            {
                var result = _UserService.SaveNewPerson(user);

                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
