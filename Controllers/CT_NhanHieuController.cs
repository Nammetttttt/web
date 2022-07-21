using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/CT_NhanHieu")]
[ApiController]
public class CT_NhanHieuController : ControllerBase
{
    private readonly ICT_NhanHieuRepository _taisanRepo;

    public CT_NhanHieuController(ICT_NhanHieuRepository taisanRepo)
    {
        _taisanRepo = taisanRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetCT_NhanHieu()
    {
        try
        {
            var compan = await _taisanRepo.GetCT_NhanHieu();
            return Ok(compan);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetCT_NhanHieu(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetCT_NhanHieu(maTK);
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
            var company = await _companyRepo.GetCT_NhanHieuByPQ_NhomQuyen_TKid(id);
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
    public async Task<IActionResult> GetCT_NhanHieuPQ_NhomQuyen_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetCT_NhanHieuPQ_NhomQuyen_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    [HttpPost]
    public async Task<IActionResult> CreateCT_NhanHieu(CT_NhanHieuForCreationDto nhanHieu)
    {
        try
        {
            var createdCT_NhanHieu = await _taisanRepo.CreateCT_NhanHieu(nhanHieu);
            return CreatedAtRoute("CompanyById",new { id = createdCT_NhanHieu.Id_NH }, createdCT_NhanHieu);
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
    public async Task<IActionResult> UpdateCT_NhanHieu(CT_NhanHieuForUpdateDto nhanHieu)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetCT_NhanHieu(nhanHieu.Id_NH);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.UpdateCT_NhanHieu(nhanHieu);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCT_NhanHieu(int Id_NH)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetCT_NhanHieu(Id_NH);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.DeleteCT_NhanHieu(Id_NH);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}