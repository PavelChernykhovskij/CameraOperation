using AutoMapper;
using CamerOperationClassLibrary.Dtos;
using CamerOperationClassLibrary.EntityFramework.Repositories;
using CamerOperationClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace CamerOperationClassLibrary.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RuleOfSearchBySpeedController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<RuleOfSearchBySpeed> _repository;

        public RuleOfSearchBySpeedController(
            IMapper mapper,
            IRepository<RuleOfSearchBySpeed> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var rules = _repository.Read();
            var dtos = rules.Select(_mapper.Map<FixationDto>).ToList();
            return Json(dtos);
        }

        [HttpPost]
        public ActionResult Create(RuleOfSearchBySpeedDto dto)
        {
            var model = _mapper.Map<RuleOfSearchBySpeed>(dto);
            _repository.Create(model);
            return Json(dto);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Json(id);
        }

        [HttpPost]
        public ActionResult Update(RuleOfSearchBySpeed data)
        {
            var rule = _mapper.Map<RuleOfSearchBySpeedDto>(data);
            _repository.Update(data);
            return Json(rule);
        }

    }
}

