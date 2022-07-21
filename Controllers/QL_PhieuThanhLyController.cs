using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/QL_PhieuThanhLy")]
[ApiController]
public class QL_PhieuThanhLyController : ControllerBase
{
    private readonly IQL_PhieuThanhLyRepository _companyRepo;

    public QL_PhieuThanhLyController(IQL_PhieuThanhLyRepository taisanRepo)
    {
        _companyRepo = taisanRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetQL_PhieuThanhLy()
    {
        try
        {
            var compan = await _companyRepo.GetQL_PhieuThanhLy();
            return Ok(compan);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetQL_PhieuThanhLy(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetQL_PhieuThanhLy(maTK);
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
            var company = await _companyRepo.GetQL_PhieuThanhLyByQL_PhieuThanhLy_TKid(id);
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
    public async Task<IActionResult> GetQL_PhieuThanhLyQL_PhieuThanhLy_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetQL_PhieuThanhLyQL_PhieuThanhLy_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    [HttpPost]
    public async Task<IActionResult> CreateQL_PhieuThanhLy(QL_PhieuThanhLyForCreationDto phieuNhap)
    {
        try
        {
            var createdQL_PhieuThanhLy = await _companyRepo.CreateQL_PhieuThanhLy(phieuNhap);
            return CreatedAtRoute("CompanyById",new { id = createdQL_PhieuThanhLy.Id_PTL }, createdQL_PhieuThanhLy);
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
    public async Task<IActionResult> UpdateQL_PhieuThanhLy(QL_PhieuThanhLyForUpdateDto phieuThanhly)
    {
        try
        {
            var dbCompany = await _companyRepo.GetQL_PhieuThanhLy(phieuThanhly.Id_PTL);
            if (dbCompany == null)
                return NotFound();

            await _companyRepo.UpdateQL_PhieuThanhLy(phieuThanhly);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteQL_PhieuThanhLy(int Id_PTL)
    {
        try
        {
            var dbCompany = await _companyRepo.GetQL_PhieuThanhLy(Id_PTL);
            if (dbCompany == null)
                return NotFound();

            await _companyRepo.DeleteQL_PhieuThanhLy(Id_PTL);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}