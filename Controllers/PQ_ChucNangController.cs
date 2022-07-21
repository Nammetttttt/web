using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/PQ_ChucNang")]
[ApiController]
public class PQ_ChucNangController : ControllerBase
{
    private readonly IPQ_ChucNangRepository _taisanRepo;

    public PQ_ChucNangController(IPQ_ChucNangRepository taisanRepo)
    {
        _taisanRepo = taisanRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetPQ_ChucNang()
    {
        try
        {
            var compan = await _taisanRepo.GetPQ_ChucNang();
            return Ok(compan);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetPQ_ChucNang(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetPQ_ChucNang(maTK);
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
            var company = await _companyRepo.GetPQ_ChucNangByPQ_ChucNang_TKid(id);
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
    public async Task<IActionResult> GetPQ_ChucNangPQ_ChucNang_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetPQ_ChucNangPQ_ChucNang_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    [HttpPost]
    public async Task<IActionResult> CreatePQ_ChucNang(PQ_ChucNangForCreationDto chucNang)
    {
        try
        {
            var createdPQ_ChucNang = await _taisanRepo.CreatePQ_ChucNang(chucNang);
            return CreatedAtRoute("CompanyById",new { id = createdPQ_ChucNang.Id_CN }, createdPQ_ChucNang);
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
    public async Task<IActionResult> UpdatePQ_ChucNang(PQ_ChucNangForUpdateDto chucNang)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetPQ_ChucNang(chucNang.Id_CN);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.UpdatePQ_ChucNang(chucNang);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePQ_ChucNang(int Id_CN)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetPQ_ChucNang(Id_CN);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.DeletePQ_ChucNang(Id_CN);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}