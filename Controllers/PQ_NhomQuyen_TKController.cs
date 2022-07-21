using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/PQ_NhomQuyen_TK")]
[ApiController]
public class PQ_NhomQuyen_TKController : ControllerBase
{
    private readonly IPQ_NhomQuyen_TKRepository _taisanRepo;

    public PQ_NhomQuyen_TKController(IPQ_NhomQuyen_TKRepository taisanRepo)
    {
        _taisanRepo = taisanRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetPQ_NhomQuyen_TK()
    {
        try
        {
            var compan = await _taisanRepo.GetPQ_NhomQuyen_TK();
            return Ok(compan);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetPQ_NhomQuyen_TK(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetPQ_NhomQuyen_TK(maTK);
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
            var company = await _companyRepo.GetPQ_NhomQuyen_TKByPQ_NhomQuyen_TK_TKid(id);
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
    public async Task<IActionResult> GetPQ_NhomQuyen_TKPQ_NhomQuyen_TK_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetPQ_NhomQuyen_TKPQ_NhomQuyen_TK_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    [HttpPost]
    public async Task<IActionResult> CreatePQ_NhomQuyen_TK(PQ_NhomQuyen_TKForCreationDto NQ_taiKhoan)
    {
        try
        {
            var createdPQ_NhomQuyen_TK = await _taisanRepo.CreatePQ_NhomQuyen_TK(NQ_taiKhoan);
            return CreatedAtRoute("CompanyById",new { id = createdPQ_NhomQuyen_TK.ID }, createdPQ_NhomQuyen_TK);
        }
        /*var createdTaiKhoan = await _companyRepo.CreateTaiKhoan(taiKhoan);
        return CreatedAtRoute("CompanyById", createdTaiKhoan.TenTK, createdTaiKhoan);*/
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    [HttpPut]
    public async Task<IActionResult> UpdatePQ_NhomQuyen_TK(PQ_NhomQuyen_TKForUpdateDto NQ_taiKhoan)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetPQ_NhomQuyen_TK(NQ_taiKhoan.ID);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.UpdatePQ_NhomQuyen_TK(NQ_taiKhoan);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePQ_NhomQuyen_TK(int ID)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetPQ_NhomQuyen_TK(ID);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.DeletePQ_NhomQuyen_TK(ID);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}