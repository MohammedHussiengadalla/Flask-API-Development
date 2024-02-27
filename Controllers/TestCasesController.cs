using Flask_API_Development.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class TestCasesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TestCasesController(ApplicationDbContext context)
    {
        _context = context;
    }


    [HttpPost("testcases")]
  
    public async Task<ActionResult<TestCase>> CreateTestCase([FromBody] TestCase testCase)
    {
        // Data validation using Data Annotations
        var validationContext = new ValidationContext(testCase, null, null);
        var validationResults = new List<ValidationResult>();
        if (!Validator.TryValidateObject(testCase, validationContext, validationResults, true))
        {
            return BadRequest(validationResults);
        }

        _context.testCases.Add(testCase);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTestCaseById), new { id = testCase.Id }, testCase);
    }

    [HttpGet("testcases")]
    //[Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<TestCase>>> GetTestCases()
    {
        return await _context.testCases.ToListAsync();
    }


    [HttpGet("testcases/{id}")]
    //[Authorize(Roles = "Admin")]
    public async Task<ActionResult<TestCase>> GetTestCaseById(int id)
    {
        var testCase = await _context.testCases.FindAsync(id);

        if (testCase == null)
        {
            return NotFound();
        }

        return testCase;
    }


    [HttpPut("testcases/{id}")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateTestCase(int id, [FromBody] TestCase updatedTestCase)
    {
        if (id != updatedTestCase.Id)
        {
            return BadRequest("Mismatched IDs");
        }

        var existingTestCase = await _context.testCases.FindAsync(id);
        if (existingTestCase == null)
        {
            return NotFound();
        }

        // Data validation using Data Annotations
        var validationContext = new ValidationContext(updatedTestCase, null, null);
        var validationResults = new List<ValidationResult>();
        if (!Validator.TryValidateObject(updatedTestCase, validationContext, validationResults, true))
        {
            return BadRequest(validationResults);
        }

        _context.Entry(existingTestCase).CurrentValues.SetValues(updatedTestCase);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TestCaseExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }


    [HttpDelete("testcases/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteTestCase(int id)
    {
        var testCase = await _context.testCases.FindAsync(id);
        if (testCase == null)
        {
            return NotFound();
        }

        _context.testCases.Remove(testCase);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TestCaseExists(int id)
    {
        return _context.testCases.Any(e => e.Id == id);
    }
}

