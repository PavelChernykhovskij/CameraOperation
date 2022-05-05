using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CamerOperationClassLibrary.Models;
using CamerOperationClassLibrary.EntityFramework.Repositories;
using CamerOperationClassLibrary.Services;
using CamerOperationClassLibrary.Dtos;

namespace CamerOperationClassLibrary.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FixationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Fixation> _repository;
        private readonly IEnumerable<IViolationDetector> _violationDetector;

        public FixationController(
            IMapper mapper,
            IRepository<Fixation> repository,
            IEnumerable<IViolationDetector> violationDetector)
        {
            _mapper = mapper;
            _repository = repository;
            _violationDetector = violationDetector;
        }

        [HttpPost]
        public ActionResult Detect(FixationDto dto)
        {
            var model = _mapper.Map<Fixation>(dto);
            _repository.Create(model);
            foreach (var violationDetector in _violationDetector)
            {
                violationDetector.ViolationDetect(model);
            }
            return Ok("Обрабтано");
        }

        [HttpPost]
        public ActionResult Create(FixationDto dto)
        {
            var model = _mapper.Map<Fixation>(dto);
            _repository.Create(model);
            return Json(model);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var fixations = _repository.Read();
            var dtos = fixations.Select(_mapper.Map<FixationDto>).ToList();
            return Json(dtos);
        }
    }
}
