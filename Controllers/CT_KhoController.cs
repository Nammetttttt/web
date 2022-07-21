using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/CT_Kho")]
[ApiController]
public class CT_KhoController : ControllerBase
{
    private readonly ICT_KhoRepository _taisanRepo;

    public CT_KhoController(ICT_KhoRepository taisanRepo)
    {
        _taisanRepo = taisanRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetCT_Kho()
    {
        try
        {
            var compan = await _taisanRepo.GetCT_Kho();
            return Ok(compan);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetCT_Kho(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetCT_Kho(maTK);
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
            var company = await _companyRepo.GetCT_KhoByPQ_NhomQuyen_TKid(id);
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
    public async Task<IActionResult> GetCT_KhoPQ_NhomQuyen_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetCT_KhoPQ_NhomQuyen_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    [HttpPost]
    public async Task<IActionResult> CreateCT_Kho(CT_KhoForCreationDto kho)
    {
        try
        {
            var createdCT_Kho = await _taisanRepo.CreateCT_Kho(kho);
            return CreatedAtRoute("CompanyById",new { id = createdCT_Kho.Id_Kho }, createdCT_Kho);
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
    public async Task<IActionResult> UpdateCT_Kho(CT_KhoForUpdateDto kho)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetCT_Kho(kho.Id_Kho);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.UpdateCT_Kho(kho);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCT_Kho(int Id_Kho)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetCT_Kho(Id_Kho);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.DeleteCT_Kho(Id_Kho);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}