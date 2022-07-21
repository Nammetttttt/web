using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/QL_PhieuXuat_ChiTiet")]
[ApiController]
public class QL_PhieuXuat_ChiTietController : ControllerBase
{
    private readonly IQL_PhieuXuat_ChiTietRepository _taisanRepo;

    public QL_PhieuXuat_ChiTietController(IQL_PhieuXuat_ChiTietRepository taisanRepo)
    {
        _taisanRepo = taisanRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetQL_PhieuXuat_ChiTiet()
    {
        try
        {
            var compan = await _taisanRepo.GetQL_PhieuXuat_ChiTiet();
            return Ok(compan);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetQL_PhieuXuat_ChiTiet(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetQL_PhieuXuat_ChiTiet(maTK);
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
            var company = await _companyRepo.GetQL_PhieuXuat_ChiTietByQL_PhieuXuat_ChiTiet_TKid(id);
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
    public async Task<IActionResult> GetQL_PhieuXuat_ChiTietQL_PhieuXuat_ChiTiet_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetQL_PhieuXuat_ChiTietQL_PhieuXuat_ChiTiet_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    [HttpPost]
    public async Task<IActionResult> CreateQL_PhieuXuat_ChiTiet(QL_PhieuXuat_ChiTietForCreationDto phieuXuatct)
    {
        try
        {
            var createdQL_PhieuXuat_ChiTiet = await _taisanRepo.CreateQL_PhieuXuat_ChiTiet(phieuXuatct);
            return CreatedAtRoute("CompanyById",new { id = createdQL_PhieuXuat_ChiTiet.ID }, createdQL_PhieuXuat_ChiTiet);
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
    public async Task<IActionResult> UpdateQL_PhieuXuat_ChiTiet(QL_PhieuXuat_ChiTietForUpdateDto phieuXuatct)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetQL_PhieuXuat_ChiTiet(phieuXuatct.Id_PX);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.UpdateQL_PhieuXuat_ChiTiet(phieuXuatct);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteQL_PhieuXuat_ChiTiet(int ID)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetQL_PhieuXuat_ChiTiet(ID);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.DeleteQL_PhieuXuat_ChiTiet(ID);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}