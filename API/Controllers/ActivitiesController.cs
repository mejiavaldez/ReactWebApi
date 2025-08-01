using System;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace API.Controllers;

public class ActivitiesController(AppDbContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await context.Activities.ToListAsync();
    }

    [HttpGet("{id}")]  
    public async Task<ActionResult<Activity>> GetActivitiesDetail(string id)
    {
        var activity = await context.Activities.FindAsync(id);

        if (activity == null) return NotFound();

        return activity;
    }

}
