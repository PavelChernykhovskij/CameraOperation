using AutoMapper;
using CamerOperationClassLibrary.Dtos;
using CamerOperationClassLibrary.EntityFramework.Repositories;
using CamerOperationClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace CamerOperationClassLibrary.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TriggeringBySpeedController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TriggeringBySpeed> _triggeringBySpeedRepo;

        public TriggeringBySpeedController(IMapper mapper, IRepository<TriggeringBySpeed> triggeringBySpeedRepo)
        {
            _mapper = mapper;
            _triggeringBySpeedRepo = triggeringBySpeedRepo;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var triggerings = _triggeringBySpeedRepo.Read();
            var dtos = triggerings.Select(_mapper.Map<FixationDto>).ToList();
            return Json(dtos);
        }
    }
}
