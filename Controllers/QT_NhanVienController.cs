using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/QT_NhanVien")]
[ApiController]
public class QT_NhanVienController : ControllerBase
{
    private readonly IQT_NhanVienRepository _taisanRepo;

    public QT_NhanVienController(IQT_NhanVienRepository taisanRepo)
    {
        _taisanRepo = taisanRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetQT_NhanVien()
    {
        try
        {
            var compan = await _taisanRepo.GetQT_NhanVien();
            return Ok(compan);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetQT_NhanVien(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetQT_NhanVien(maTK);
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
            var company = await _companyRepo.GetQT_NhanVienByQT_NhanVien_TKid(id);
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
    public async Task<IActionResult> GetQT_NhanVienQT_NhanVien_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetQT_NhanVienQT_NhanVien_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    [HttpPost]
    public async Task<IActionResult> CreateQT_NhanVien(QT_NhanVienForCreationDto nhanVien)
    {
        try
        {
            var createdQT_NhanVien = await _taisanRepo.CreateQT_NhanVien(nhanVien);
            return CreatedAtRoute("CompanyById",new { id = createdQT_NhanVien.Id_NV }, createdQT_NhanVien);
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
    public async Task<IActionResult> UpdateQT_NhanVien(QT_NhanVienForUpdateDto nhanVien)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetQT_NhanVien(nhanVien.Id_NV);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.UpdateQT_NhanVien(nhanVien);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteQT_NhanVien(int Id_NV)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetQT_NhanVien(Id_NV);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.DeleteQT_NhanVien(Id_NV);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}