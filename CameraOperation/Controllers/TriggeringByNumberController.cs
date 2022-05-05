using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CamerOperationClassLibrary.Models;
using CamerOperationClassLibrary.EntityFramework.Repositories;
using CamerOperationClassLibrary.Dtos;

namespace CamerOperationClassLibrary.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TriggeringByNumberController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TriggeringByNumber> _triggeringByNumberRepo;

        public TriggeringByNumberController(IMapper mapper, IRepository<TriggeringByNumber> triggeringByNumberRepo)
        {
            _mapper = mapper;
            _triggeringByNumberRepo = triggeringByNumberRepo;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var triggerings = _triggeringByNumberRepo.Read();
            var dtos = triggerings.Select(_mapper.Map<FixationDto>).ToList();
            return Json(dtos);
        }
    }
}
