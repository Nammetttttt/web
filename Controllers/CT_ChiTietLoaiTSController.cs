using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/CT_ChiTietLoaiTS")]
[ApiController]
public class CT_ChiTietLoaiTSController : ControllerBase
{
    private readonly ICT_ChiTietLoaiTSRepository _taisanRepo;

    public CT_ChiTietLoaiTSController(ICT_ChiTietLoaiTSRepository taisanRepo)
    {
        _taisanRepo = taisanRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetCT_ChiTietLoaiTS()
    {
        try
        {
            var compan = await _taisanRepo.GetCT_ChiTietLoaiTS();
            return Ok(compan);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetCT_ChiTietLoaiTS(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetCT_ChiTietLoaiTS(maTK);
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
            var company = await _companyRepo.GetCT_ChiTietLoaiTSByPQ_NhomQuyen_TKid(id);
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
    public async Task<IActionResult> GetCT_ChiTietLoaiTSPQ_NhomQuyen_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetCT_ChiTietLoaiTSPQ_NhomQuyen_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    [HttpPost]
    public async Task<IActionResult> CreateCT_ChiTietLoaiTS(CT_ChiTietLoaiTSForCreationDto loai)
    {
        try
        {
            var createdCT_ChiTietLoaiTS = await _taisanRepo.CreateCT_ChiTietLoaiTS(loai);
            return CreatedAtRoute("CompanyById",new { id = createdCT_ChiTietLoaiTS.Id_Loai }, createdCT_ChiTietLoaiTS);
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
    public async Task<IActionResult> UpdateCT_ChiTietLoaiTS(CT_ChiTietLoaiTSForUpdateDto loai)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetCT_ChiTietLoaiTS(loai.Id_Loai);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.UpdateCT_ChiTietLoaiTS(loai);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCT_ChiTietLoaiTS(int Id_Loai)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetCT_ChiTietLoaiTS(Id_Loai);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.DeleteCT_ChiTietLoaiTS(Id_Loai);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}