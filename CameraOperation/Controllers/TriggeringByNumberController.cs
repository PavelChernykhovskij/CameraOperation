﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CamerOperationClassLibrary.Models;
using CamerOperationClassLibrary.AutoMapping.DtoModels;
using CamerOperationClassLibrary.EntityFramework.Repositories;
using CamerOperationClassLibrary.Services;

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
            List<TriggeringByNumberDto> dtos = new();
            foreach (TriggeringByNumber triggering in triggerings)
            {
                dtos.Add(_mapper.Map<TriggeringByNumberDto>(triggering));
            }
            return Json(dtos);
        }
    }
}
