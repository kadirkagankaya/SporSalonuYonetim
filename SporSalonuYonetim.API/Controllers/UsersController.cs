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
    public class UsersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<User> _service;

        public UsersController(IService<User> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await _service.GetAllAsync();
            var usersDtos = _mapper.Map<List<UserDto>>(users.Data);
            return CreateActionResult(ServiceResponse<List<UserDto>>.SuccessResult(usersDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _service.GetByIdAsync(id);
            var userDto = _mapper.Map<UserDto>(user.Data);
            return CreateActionResult(ServiceResponse<UserDto>.SuccessResult(userDto));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Save(UserCreateDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var userCreated = await _service.AddAsync(user);
            var userCreatedDto = _mapper.Map<UserDto>(userCreated.Data);
            return CreateActionResult(ServiceResponse<UserDto>.SuccessResult(userCreatedDto, 201));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateDto userDto)
        {
            var userResponse = await _service.GetByIdAsync(userDto.Id);
            if (!userResponse.Success)
            {
                return CreateActionResult(ServiceResponse<NoContentDto>.FailResult("Kullanıcı bulunamadı", 404));
            }

            var user = userResponse.Data;
            _mapper.Map(userDto, user);
            
            await _service.UpdateAsync(user);
            return CreateActionResult(ServiceResponse<NoContentDto>.SuccessResult(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _service.RemoveAsync(id);
            return CreateActionResult(ServiceResponse<NoContentDto>.SuccessResult(204));
        }
    }
}
