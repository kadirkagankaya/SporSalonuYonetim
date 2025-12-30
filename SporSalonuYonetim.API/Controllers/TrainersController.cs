using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SporSalonuYonetim.Core.DTOs;
using SporSalonuYonetim.Core.Entities;
using SporSalonuYonetim.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

namespace SporSalonuYonetim.API.Controllers
{
    [Authorize]
    public class TrainersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Trainer> _service;

        public TrainersController(IService<Trainer> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var trainers = await _service.GetAllAsync();
            var trainerDtos = _mapper.Map<List<TrainerDto>>(trainers.Data);
            return CreateActionResult(ServiceResponse<List<TrainerDto>>.SuccessResult(trainerDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save(TrainerCreateDto trainerDto)
        {
            var trainer = _mapper.Map<Trainer>(trainerDto);
            var trainerCreated = await _service.AddAsync(trainer);
            var trainerCreatedDto = _mapper.Map<TrainerDto>(trainerCreated.Data);
            return CreateActionResult(ServiceResponse<TrainerDto>.SuccessResult(trainerCreatedDto, 201));
        }
    }
}
