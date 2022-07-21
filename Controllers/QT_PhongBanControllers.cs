using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/QT_PhongBan")]
[ApiController]
public class QT_PhongBanController : ControllerBase
{
    private readonly IQT_PhongBanRepository _taisanRepo;

    public QT_PhongBanController(IQT_PhongBanRepository taisanRepo)
    {
        _taisanRepo = taisanRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetQT_PhongBan()
    {
        try
        {
            var compan = await _taisanRepo.GetQT_PhongBan();
            return Ok(compan);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetQT_PhongBan(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetQT_PhongBan(maTK);
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
            var company = await _companyRepo.GetQT_PhongBanByPQ_NhomQuyen_TKid(id);
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
    public async Task<IActionResult> GetQT_PhongBanPQ_NhomQuyen_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetQT_PhongBanPQ_NhomQuyen_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    [HttpPost]
    public async Task<IActionResult> CreateQT_PhongBan(QT_PhongBanForCreationDto phongBan)
    {
        try
        {
            var createdQT_PhongBan = await _taisanRepo.CreateQT_PhongBan(phongBan);
            return CreatedAtRoute("CompanyById",new { id = createdQT_PhongBan.Id_PB }, createdQT_PhongBan);
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
    public async Task<IActionResult> UpdateQT_PhongBan(QT_PhongBanForUpdateDto phongBan)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetQT_PhongBan(phongBan.Id_PB);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.UpdateQT_PhongBan(phongBan);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteQT_PhongBan(int Id_PB)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetQT_PhongBan(Id_PB);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.DeleteQT_PhongBan(Id_PB);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}