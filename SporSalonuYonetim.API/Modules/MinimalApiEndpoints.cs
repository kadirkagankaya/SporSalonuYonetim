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
            var features = app.MapGroup("/api/features");

            features.MapGet("/subscriptions", async ([FromServices] IService<SubscriptionType> service) =>
            {
                var response = await service.GetAllAsync();
                return Results.Ok(response);
            });

            features.MapGet("/subscriptions/{id}", async ([FromServices] IService<SubscriptionType> service, Guid id) =>
            {
                var response = await service.GetByIdAsync(id);
                if (!response.Success) return Results.NotFound(response);
                return Results.Ok(response);
            });

            features.MapPost("/subscriptions", async ([FromServices] IService<SubscriptionType> service, SubscriptionType entity) =>
            {
                var response = await service.AddAsync(entity);
                return Results.Created($"/api/features/subscriptions/{entity.Id}", response);
            });

            features.MapGet("/workouts", async ([FromServices] IService<WorkoutProgram> service) =>
            {
                var response = await service.GetAllAsync();
                return Results.Ok(response);
            });

            features.MapPost("/workouts", async ([FromServices] IService<WorkoutProgram> service, WorkoutProgram entity) =>
            {
                // DTO mapping should normally happen here, but for brevity/demo we use entity directly or mapping in required
                // In a real scenario we'd inject IMapper
                var response = await service.AddAsync(entity);
                return Results.Created($"/api/features/workouts/{entity.Id}", response);
            });
        }
    }
}
