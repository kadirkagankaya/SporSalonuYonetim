using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SporSalonuYonetim.Core.DTOs;
using SporSalonuYonetim.Core.Entities;
using SporSalonuYonetim.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace SporSalonuYonetim.API.Modules
{
    public static class MinimalApiEndpoints
    {
        public static void RegisterMinimalEndpoints(this WebApplication app)
        {
            var features = app.MapGroup("/api/features").RequireAuthorization();

            features.MapGet("/subscriptions", async ([FromServices] IService<SubscriptionType> service, [FromServices] IMapper mapper) =>
            {
                var response = await service.GetAllAsync();
                var result = mapper.Map<List<SubscriptionTypeDto>>(response.Data);
                return Results.Ok(ServiceResponse<List<SubscriptionTypeDto>>.SuccessResult(result));
            });

            features.MapGet("/subscriptions/{id}", async ([FromServices] IService<SubscriptionType> service, [FromServices] IMapper mapper, Guid id) =>
            {
                var response = await service.GetByIdAsync(id);
                if (!response.Success) return Results.NotFound(response);
                var result = mapper.Map<SubscriptionTypeDto>(response.Data);
                return Results.Ok(ServiceResponse<SubscriptionTypeDto>.SuccessResult(result));
            });

            features.MapPost("/subscriptions", async ([FromServices] IService<SubscriptionType> service, [FromServices] IMapper mapper, SubscriptionTypeCreateDto dto) =>
            {
                var entity = mapper.Map<SubscriptionType>(dto);
                var response = await service.AddAsync(entity);
                var resultDto = mapper.Map<SubscriptionTypeDto>(response.Data);
                return Results.Created($"/api/features/subscriptions/{entity.Id}", ServiceResponse<SubscriptionTypeDto>.SuccessResult(resultDto, 201));
            });

            features.MapGet("/workouts", async ([FromServices] IService<WorkoutProgram> service, [FromServices] IMapper mapper) =>
            {
                var response = await service.GetAllAsync();
                var result = mapper.Map<List<WorkoutProgramDto>>(response.Data);
                return Results.Ok(ServiceResponse<List<WorkoutProgramDto>>.SuccessResult(result));
            });

            features.MapPost("/workouts", async ([FromServices] IService<WorkoutProgram> service, [FromServices] IMapper mapper, WorkoutProgramCreateDto dto) =>
            {
                var entity = mapper.Map<WorkoutProgram>(dto);
                var response = await service.AddAsync(entity);
                var resultDto = mapper.Map<WorkoutProgramDto>(response.Data);
                return Results.Created($"/api/features/workouts/{entity.Id}", ServiceResponse<WorkoutProgramDto>.SuccessResult(resultDto, 201));
            });
        }
    }
}
