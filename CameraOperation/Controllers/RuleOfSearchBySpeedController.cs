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
    public class RuleOfSearchBySpeedController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRuleOfSearchRepository<RuleOfSearchBySpeed> _ruleOfSearchBySpeedRepo;

        public RuleOfSearchBySpeedController(IMapper mapper, IRuleOfSearchRepository<RuleOfSearchBySpeed> ruleOfSearchBySpeedRepo)
        {
            _mapper = mapper;
            _ruleOfSearchBySpeedRepo = ruleOfSearchBySpeedRepo;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var rules = _ruleOfSearchBySpeedRepo.ReadAll();
            List<RuleOfSearchBySpeedDto> dtos = new();
            foreach (RuleOfSearchBySpeed rule in rules)
            {
                dtos.Add(_mapper.Map<RuleOfSearchBySpeedDto>(rule));
            }
            return Json(dtos);
        }

        [HttpGet]
        public ActionResult GetOne()
        {
            var rule = _ruleOfSearchBySpeedRepo.ReadOne();
            var ruleDto = _mapper.Map<RuleOfSearchBySpeedDto>(rule);
            return Json(ruleDto);
        }

        [HttpPost]
        public ActionResult Create(RuleOfSearchBySpeedDto model)
        {
            var rule = _mapper.Map<RuleOfSearchBySpeed>(model);
            _ruleOfSearchBySpeedRepo.Create(rule);
            return Json(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _ruleOfSearchBySpeedRepo.Delete(id);
            return Json(id);
        }

        [HttpPost]
        public ActionResult Update(RuleOfSearchBySpeed data)
        {
            var rule = _mapper.Map<RuleOfSearchBySpeedDto>(data);
            _ruleOfSearchBySpeedRepo.Update(data);
            return Json(rule);
        }

    }
}

