using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/QT_TaiSan")]
[ApiController]
public class QT_TaiSanController : ControllerBase
{
    private readonly IQT_TaiSanRepository _taisanRepo;

    public QT_TaiSanController(IQT_TaiSanRepository taisanRepo)
    {
        _taisanRepo = taisanRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetQT_TaiSan()
    {
        try
        {
            var compan = await _taisanRepo.GetQT_TaiSan();
            return Ok(compan);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetQT_TaiSan(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetQT_TaiSan(maTK);
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
            var company = await _companyRepo.GetQT_TaiSanByPQ_NhomQuyen_TKid(id);
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
    public async Task<IActionResult> GetQT_TaiSanPQ_NhomQuyen_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetQT_TaiSanPQ_NhomQuyen_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    [HttpPost]
    public async Task<IActionResult> CreateQT_TaiSan(QT_TaiSanForCreationDto taiKhoan)
    {
        try
        {
            var createdQT_TaiSan = await _taisanRepo.CreateQT_TaiSan(taiKhoan);
            return CreatedAtRoute("CompanyById",new { id = createdQT_TaiSan.Id_TS }, createdQT_TaiSan);
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
    public async Task<IActionResult> UpdateQT_TaiSan(QT_TaiSanForUpdateDto taisan)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetQT_TaiSan(taisan.Id_TS);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.UpdateQT_TaiSan(taisan);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteQT_TaiSan(int Id_TS)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetQT_TaiSan(Id_TS);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.DeleteQT_TaiSan(Id_TS);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}