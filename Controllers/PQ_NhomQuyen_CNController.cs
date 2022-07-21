using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/PQ_NhomQuyen_CN")]
[ApiController]
public class PQ_NhomQuyen_CNController : ControllerBase
{
    private readonly IPQ_NhomQuyen_CNRepository _taisanRepo;

    public PQ_NhomQuyen_CNController(IPQ_NhomQuyen_CNRepository taisanRepo)
    {
        _taisanRepo = taisanRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetPQ_NhomQuyen_CN()
    {
        try
        {
            var compan = await _taisanRepo.GetPQ_NhomQuyen_CN();
            return Ok(compan);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetPQ_NhomQuyen_CN(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetPQ_NhomQuyen_CN(maTK);
            if (company == null)
                return NotFound();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    /*[HttpGet("ByEmployeeId/{id}")]
    public async Task<IActionResult> GetCompanyForEmployee(int id)
    {
        try
        {
            var company = await _companyRepo.GetPQ_NhomQuyen_CNByPQ_NhomQuyen_CN_TKid(id);
            if (company == null)
                return NotFound();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    /*[HttpGet("MultipleMapping")]
    public async Task<IActionResult> GetPQ_NhomQuyen_CNPQ_NhomQuyen_CN_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetPQ_NhomQuyen_CNPQ_NhomQuyen_CN_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    /* [HttpPost]
     public async Task<IActionResult> GetPQ_NhomQuyen_CN(int Id_NQ)
     {
         try
         {
             var compan = await _taisanRepo.GetPQ_NhomQuyen_CN(Id_NQ);
             return Ok(compan);
         }
         catch (Exception ex)
         {
             //log error
             return StatusCode(500, ex.Message);
         }
     }*/
    [HttpPost]
    public async Task<IActionResult> CreatePQ_NhomQuyen_CN(PQ_NhomQuyen_CNForCreationDto NQ_chucNang)
    {
        try
        {
            var createdPQ_NhomQuyen_CN = await _taisanRepo.CreatePQ_NhomQuyen_CN(NQ_chucNang);
            return CreatedAtRoute("CompanyById", new { id = createdPQ_NhomQuyen_CN.ID }, createdPQ_NhomQuyen_CN);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpPut]
    public async Task<IActionResult> GetPQ_NhomQuyen_CN(int Id_NQ)
    {
        try
        {
            var compan = await _taisanRepo.GetPQ_NhomQuyen_CN(Id_NQ);
            return Ok(compan);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/
    [HttpPut]
    public async Task<IActionResult> UpdatePQ_NhomQuyen_CN(PQ_NhomQuyen_CNForUpdateDto NQ_chucNang)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetPQ_NhomQuyen_CN(NQ_chucNang.ID);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.UpdatePQ_NhomQuyen_CN(NQ_chucNang);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePQ_NhomQuyen_CN(int ID)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetPQ_NhomQuyen_CN_(ID);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.DeletePQ_NhomQuyen_CN(ID);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}