using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/QL_PhieuThanhLy_ChiTiet")]
[ApiController]
public class QL_PhieuThanhLy_ChiTietController : ControllerBase
{
    private readonly IQL_PhieuThanhLy_ChiTietRepository _taisanRepo;

    public QL_PhieuThanhLy_ChiTietController(IQL_PhieuThanhLy_ChiTietRepository taisanRepo)
    {
        _taisanRepo = taisanRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetQL_PhieuThanhLy_ChiTiet()
    {
        try
        {
            var compan = await _taisanRepo.GetQL_PhieuThanhLy_ChiTiet();
            return Ok(compan);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetQL_PhieuThanhLy_ChiTiet(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetQL_PhieuThanhLy_ChiTiet(maTK);
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
            var company = await _companyRepo.GetQL_PhieuThanhLy_ChiTietByQL_PhieuThanhLy_ChiTiet_TKid(id);
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
    public async Task<IActionResult> GetQL_PhieuThanhLy_ChiTietQL_PhieuThanhLy_ChiTiet_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetQL_PhieuThanhLy_ChiTietQL_PhieuThanhLy_ChiTiet_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    [HttpPost]
    public async Task<IActionResult> CreateQL_PhieuThanhLy_ChiTiet(QL_PhieuThanhLy_ChiTietForCreationDto phieuThanhlyct)
    {
        try
        {
            var createdQL_PhieuThanhLy_ChiTiet = await _taisanRepo.CreateQL_PhieuThanhLy_ChiTiet(phieuThanhlyct);
            return CreatedAtRoute("CompanyById",new { id = createdQL_PhieuThanhLy_ChiTiet.ID }, createdQL_PhieuThanhLy_ChiTiet);
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
    public async Task<IActionResult> UpdateQL_PhieuThanhLy_ChiTiet(QL_PhieuThanhLy_ChiTietForUpdateDto phieuThanhlyct)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetQL_PhieuThanhLy_ChiTiet(phieuThanhlyct.Id_PTL);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.UpdateQL_PhieuThanhLy_ChiTiet(phieuThanhlyct);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteQL_PhieuThanhLy_ChiTiet(int ID)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetQL_PhieuThanhLy_ChiTiet(ID);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.DeleteQL_PhieuThanhLy_ChiTiet(ID);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}