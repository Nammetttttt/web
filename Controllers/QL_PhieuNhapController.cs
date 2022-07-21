using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/QL_PhieuNhap")]
[ApiController]
public class QL_PhieuNhapController : ControllerBase
{
    private readonly IQL_PhieuNhapRepository _companyRepo;

    public QL_PhieuNhapController(IQL_PhieuNhapRepository taisanRepo)
    {
        _companyRepo = taisanRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetQL_PhieuNhap()
    {
        try
        {
            var compan = await _companyRepo.GetQL_PhieuNhap();
            return Ok(compan);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetQL_PhieuNhap(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetQL_PhieuNhap(maTK);
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
            var company = await _companyRepo.GetQL_PhieuNhapByQL_PhieuNhap_TKid(id);
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
    public async Task<IActionResult> GetQL_PhieuNhapQL_PhieuNhap_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetQL_PhieuNhapQL_PhieuNhap_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    [HttpPost]
    public async Task<IActionResult> CreateQL_PhieuNhap(QL_PhieuNhapForCreationDto phieuNhap)
    {
        try
        {
            var createdQL_PhieuNhap = await _companyRepo.CreateQL_PhieuNhap(phieuNhap);
            return CreatedAtRoute("CompanyById",new { id = createdQL_PhieuNhap.Id_PN }, createdQL_PhieuNhap);
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
    public async Task<IActionResult> UpdateQL_PhieuNhap(QL_PhieuNhapForUpdateDto phieuNhap)
    {
        try
        {
            var dbCompany = await _companyRepo.GetQL_PhieuNhap(phieuNhap.Id_PN);
            if (dbCompany == null)
                return NotFound();

            await _companyRepo.UpdateQL_PhieuNhap(phieuNhap);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteQL_PhieuNhap(int Id_PN)
    {
        try
        {
            var dbCompany = await _companyRepo.GetQL_PhieuNhap(Id_PN);
            if (dbCompany == null)
                return NotFound();

            await _companyRepo.DeleteQL_PhieuNhap(Id_PN);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}