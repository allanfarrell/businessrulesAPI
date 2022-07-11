namespace RulesEngine.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LoxSharp;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    [HttpGet("validate")]
    public IActionResult ValidateInput()
    {
        return Ok("Validate");
    }

    [HttpGet("create")]
    public IActionResult CreateRule(int id)
    {
        return Ok("CreateRule");
    }

    [HttpGet("update")]
    public IActionResult UpdateRule(int id)
    {
        return Ok("UpdateRule");
    }

    [HttpGet("delete")]
    public IActionResult v(int id)
    {
        return Ok("SoftDeleteRule");
    }

    [HttpGet("get")]
    public IActionResult GetRule(int id)
    {
        return Ok("GetRule");
    }

    [HttpGet("all")]
    public IActionResult GetAllRules(int id)
    {
        return Ok("GetAllRules");
    }
}