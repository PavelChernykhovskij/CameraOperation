using Microsoft.AspNetCore.Http;
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
    public class FixationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Fixation> _fixation;
        private readonly IEnumerable<IViolationDetector> _violationDetector;

        public FixationController(IMapper mapper, IEnumerable<IViolationDetector> violationDetector,
            IRepository<Fixation> fixationRepo)
        {
            _mapper = mapper;
            _fixation = fixationRepo;
            _violationDetector = violationDetector;
        }

        [HttpPost]
        public ActionResult Detect(FixationDto model)
        {
            var fixation = _mapper.Map<Fixation>(model);
            _fixation.Create(fixation);
            foreach (var violationDetector in _violationDetector)
            {
                violationDetector.ViolationDetect(fixation);
            }
            return Json("Ok");
        }

        [HttpPost]
        public ActionResult Create(FixationDto model)
        {
            var fixation = _mapper.Map<Fixation>(model);
            _fixation.Create(fixation);
            return Json(model);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var fixations = _fixation.Read();
            List<FixationDto> dtos = new();
            foreach (Fixation fixation in fixations)
            {
                dtos.Add(_mapper.Map<FixationDto>(fixation));
            }
            return Json(dtos);
        }
    }
}
