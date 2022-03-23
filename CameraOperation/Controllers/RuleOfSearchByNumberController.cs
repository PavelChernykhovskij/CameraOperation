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
    public class RuleOfSearchByNumberController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRuleOfSearchRepository<RuleOfSearchByNumber> _ruleOfSearchByNumberRepo;

        public RuleOfSearchByNumberController(IMapper mapper, IRuleOfSearchRepository<RuleOfSearchByNumber> ruleOfSearchByNumberRepo)
        {
            _mapper = mapper;
            _ruleOfSearchByNumberRepo = ruleOfSearchByNumberRepo;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var rules = _ruleOfSearchByNumberRepo.ReadAll();
            List<RuleOfSearchByNumberDto> dtos = new();
            foreach (RuleOfSearchByNumber rule in rules)
            {
                dtos.Add(_mapper.Map<RuleOfSearchByNumberDto>(rule));
            }
            return Json(dtos);
        }

        [HttpGet]
        public ActionResult GetOne()
        {
            var rule = _ruleOfSearchByNumberRepo.ReadOne();
            var ruleDto = _mapper.Map<RuleOfSearchByNumberDto>(rule);
            return Json(ruleDto);
        }

        [HttpPost]
        public ActionResult Create(RuleOfSearchByNumberDto model)
        {
            var rule = _mapper.Map<RuleOfSearchByNumber>(model);
            _ruleOfSearchByNumberRepo.Create(rule);
            return Json(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _ruleOfSearchByNumberRepo.Delete(id);
            return Json(id);
        }

        [HttpPost]
        public ActionResult Update(RuleOfSearchByNumber data)
        {
            var rule = _mapper.Map<RuleOfSearchByNumberDto>(data);
            _ruleOfSearchByNumberRepo.Update(data);
            return Json(rule);
        }

    }
}

