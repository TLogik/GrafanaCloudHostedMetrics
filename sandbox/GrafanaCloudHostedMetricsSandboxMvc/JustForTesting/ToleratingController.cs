// <copyright file="ToleratingController.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using GrafanaCloudHostedMetricsSandboxMvc.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace GrafanaCloudHostedMetricsSandboxMvc.JustForTesting
{
    [Route("api/[controller]")]
    public class ToleratingController : Controller
    {
        private readonly RequestDurationForApdexTesting _durationForApdexTesting;

        public ToleratingController(RequestDurationForApdexTesting durationForApdexTesting)
        {
            _durationForApdexTesting = durationForApdexTesting;
        }

        [HttpGet]
        public async Task<int> Get()
        {
            var duration = _durationForApdexTesting.NextToleratingDuration;

            await Task.Delay(duration, HttpContext.RequestAborted);

            return duration;
        }
    }
}