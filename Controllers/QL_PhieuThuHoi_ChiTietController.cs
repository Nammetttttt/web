using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/QL_PhieuThuHoi_ChiTiet")]
[ApiController]
public class QL_PhieuThuHoi_ChiTietController : ControllerBase
{
    private readonly IQL_PhieuThuHoi_ChiTietRepository _taisanRepo;

    public QL_PhieuThuHoi_ChiTietController(IQL_PhieuThuHoi_ChiTietRepository taisanRepo)
    {
        _taisanRepo = taisanRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetQL_PhieuThuHoi_ChiTiet()
    {
        try
        {
            var compan = await _taisanRepo.GetQL_PhieuThuHoi_ChiTiet();
            return Ok(compan);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetQL_PhieuThuHoi_ChiTiet(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetQL_PhieuThuHoi_ChiTiet(maTK);
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
            var company = await _companyRepo.GetQL_PhieuThuHoi_ChiTietByQL_PhieuThuHoi_ChiTiet_TKid(id);
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
    public async Task<IActionResult> GetQL_PhieuThuHoi_ChiTietQL_PhieuThuHoi_ChiTiet_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetQL_PhieuThuHoi_ChiTietQL_PhieuThuHoi_ChiTiet_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    [HttpPost]
    public async Task<IActionResult> CreateQL_PhieuThuHoi_ChiTiet(QL_PhieuThuHoi_ChiTietForCreationDto phieuThuhoict)
    {
        try
        {
            var createdQL_PhieuThuHoi_ChiTiet = await _taisanRepo.CreateQL_PhieuThuHoi_ChiTiet(phieuThuhoict);
            return CreatedAtRoute("CompanyById",new { id = createdQL_PhieuThuHoi_ChiTiet.ID }, createdQL_PhieuThuHoi_ChiTiet);
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
    public async Task<IActionResult> UpdateQL_PhieuThuHoi_ChiTiet(QL_PhieuThuHoi_ChiTietForUpdateDto phieuThuhoict)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetQL_PhieuThuHoi_ChiTiet(phieuThuhoict.Id_PTH);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.UpdateQL_PhieuThuHoi_ChiTiet(phieuThuhoict);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteQL_PhieuThuHoi_ChiTiet(int ID)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetQL_PhieuThuHoi_ChiTiet(ID);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.DeleteQL_PhieuThuHoi_ChiTiet(ID);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}