using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/QL_PhieuThuHoi")]
[ApiController]
public class QL_PhieuThuHoiController : ControllerBase
{
    private readonly IQL_PhieuThuHoiRepository _companyRepo;

    public QL_PhieuThuHoiController(IQL_PhieuThuHoiRepository taisanRepo)
    {
        _companyRepo = taisanRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetQL_PhieuThuHoi()
    {
        try
        {
            var compan = await _companyRepo.GetQL_PhieuThuHoi();
            return Ok(compan);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetQL_PhieuThuHoi(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetQL_PhieuThuHoi(maTK);
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
            var company = await _companyRepo.GetQL_PhieuThuHoiByQL_PhieuThuHoi_TKid(id);
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
    public async Task<IActionResult> GetQL_PhieuThuHoiQL_PhieuThuHoi_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetQL_PhieuThuHoiQL_PhieuThuHoi_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    [HttpPost]
    public async Task<IActionResult> CreateQL_PhieuThuHoi(QL_PhieuThuHoiForCreationDto phieuThuhoi)
    {
        try
        {
            var createdQL_PhieuThuHoi = await _companyRepo.CreateQL_PhieuThuHoi(phieuThuhoi);
            return CreatedAtRoute("CompanyById",new { id = createdQL_PhieuThuHoi.Id_PTH }, createdQL_PhieuThuHoi);
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
    public async Task<IActionResult> UpdateQL_PhieuThuHoi(QL_PhieuThuHoiForUpdateDto phieuThuhoi)
    {
        try
        {
            var dbCompany = await _companyRepo.GetQL_PhieuThuHoi(phieuThuhoi.Id_PTH);
            if (dbCompany == null)
                return NotFound();

            await _companyRepo.UpdateQL_PhieuThuHoi(phieuThuhoi);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteQL_PhieuThuHoi(int Id_PTH)
    {
        try
        {
            var dbCompany = await _companyRepo.GetQL_PhieuThuHoi(Id_PTH);
            if (dbCompany == null)
                return NotFound();

            await _companyRepo.DeleteQL_PhieuThuHoi(Id_PTH);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}