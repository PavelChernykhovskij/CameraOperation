using AutoMapper;
using CamerOperationClassLibrary.Dtos;
using CamerOperationClassLibrary.EntityFramework.Repositories;
using CamerOperationClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace CamerOperationClassLibrary.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RuleOfSearchByNumberController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<RuleOfSearchByNumber> _repository;

        public RuleOfSearchByNumberController(
            IMapper mapper,
            IRepository<RuleOfSearchByNumber> repository)
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
        public ActionResult Create(RuleOfSearchByNumberDto dto)
        {
            var model = _mapper.Map<RuleOfSearchByNumber>(dto);
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
        public ActionResult Update(RuleOfSearchByNumber data)
        {
            var rule = _mapper.Map<RuleOfSearchByNumberDto>(data);
            _repository.Update(data);
            return Json(rule);
        }
    }
}

