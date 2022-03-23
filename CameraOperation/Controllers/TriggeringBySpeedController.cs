using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CameraOperation.Models;
using CameraOperation.AutoMapping.DtoModels;
using CameraOperation.EntityFramework.Repositories;
using CameraOperation.Services;

namespace CameraOperation.Controllers
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
            List<TriggeringBySpeedDto> dtos = new();
            foreach (TriggeringBySpeed triggering in triggerings)
            {
                dtos.Add(_mapper.Map<TriggeringBySpeedDto>(triggering));
            }
            return Json(dtos);
        }
    }
}
