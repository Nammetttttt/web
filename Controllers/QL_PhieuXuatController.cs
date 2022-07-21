using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/QL_PhieuXuat")]
[ApiController]
public class QL_PhieuXuatController : ControllerBase
{
    private readonly IQL_PhieuXuatRepository _companyRepo;

    public QL_PhieuXuatController(IQL_PhieuXuatRepository taisanRepo)
    {
        _companyRepo = taisanRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetQL_PhieuXuat()
    {
        try
        {
            var compan = await _companyRepo.GetQL_PhieuXuat();
            return Ok(compan);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetQL_PhieuXuat(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetQL_PhieuXuat(maTK);
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
            var company = await _companyRepo.GetQL_PhieuXuatByQL_PhieuXuat_TKid(id);
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
    public async Task<IActionResult> GetQL_PhieuXuatQL_PhieuXuat_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetQL_PhieuXuatQL_PhieuXuat_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    [HttpPost]
    public async Task<IActionResult> CreateQL_PhieuXuat(QL_PhieuXuatForCreationDto phieuXuat)
    {
        try
        {
            var createdQL_PhieuXuat = await _companyRepo.CreateQL_PhieuXuat(phieuXuat);
            return CreatedAtRoute("CompanyById",new { id = createdQL_PhieuXuat.Id_PX }, createdQL_PhieuXuat);
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
    public async Task<IActionResult> UpdateQL_PhieuXuat(QL_PhieuXuatForUpdateDto phieuXuat)
    {
        try
        {
            var dbCompany = await _companyRepo.GetQL_PhieuXuat(phieuXuat.Id_PX);
            if (dbCompany == null)
                return NotFound();

            await _companyRepo.UpdateQL_PhieuXuat(phieuXuat);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteQL_PhieuXuat(int Id_PX)
    {
        try
        {
            var dbCompany = await _companyRepo.GetQL_PhieuXuat(Id_PX);
            if (dbCompany == null)
                return NotFound();

            await _companyRepo.DeleteQL_PhieuXuat(Id_PX);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}