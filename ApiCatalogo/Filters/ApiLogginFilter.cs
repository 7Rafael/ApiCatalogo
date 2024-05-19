﻿using Microsoft.AspNetCore.Mvc.Filters;


public class ApiLogginFilter : IActionFilter
{
    private readonly ILogger<ApiLogginFilter> _logger;

    public ApiLogginFilter(ILogger<ApiLogginFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation($"ANTES DA EXECUÇÃO");
        _logger.LogInformation($"####################################");
        _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
        _logger.LogInformation($"ModelState : {context.ModelState.IsValid}");
        _logger.LogInformation($"####################################");
    }
    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation($"ANTES DA EXECUÇÃO");
        _logger.LogInformation($"####################################");
        _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
        _logger.LogInformation($"Status code : {context.HttpContext.Response.StatusCode}");
        _logger.LogInformation($"####################################");
    }

}

