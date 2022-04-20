using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CamerOperationClassLibrary.Models;
using CamerOperationClassLibrary.AutoMapping.DtoModels;
using CamerOperationClassLibrary.EntityFramework.Repositories;
using CamerOperationClassLibrary.Services;

namespace CamerOperationClassLibrary.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepo;

        public UserController(IMapper mapper, IRepository<User> userRepo)
        {
            _mapper = mapper;
            _userRepo = userRepo;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var users = _userRepo.Read();
            List<UserDto> dtos = new();
            foreach (User user in users)
            {
                dtos.Add(_mapper.Map<UserDto>(user));
            }
            return Json(dtos);
        }
    }
}
