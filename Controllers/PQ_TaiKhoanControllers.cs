using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/PQ_TaiKhoan")]
[ApiController]
public class PQ_TaiKhoanController : ControllerBase
{
    private readonly IPQ_TaiKhoanRepository _companyRepo;

    public PQ_TaiKhoanController(IPQ_TaiKhoanRepository companyRepo)
    {
        _companyRepo = companyRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetPQ_TaiKhoan()
    {
        try
        {
            var companies = await _companyRepo.GetPQ_TaiKhoan();
            return Ok(companies);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetPQ_TaiKhoan(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetPQ_TaiKhoan(maTK);
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
            var company = await _companyRepo.GetPQ_TaiKhoanByPQ_NhomQuyen_TKid(id);
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
    public async Task<IActionResult> GetPQ_TaiKhoanPQ_NhomQuyen_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetPQ_TaiKhoanPQ_NhomQuyen_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    [HttpPost]
    public async Task<IActionResult> CreatePQ_TaiKhoan(PQ_TaiKhoanForCreationDto taiKhoan)
    {
        try
        {
            var createdPQ_TaiKhoan = await _companyRepo.CreatePQ_TaiKhoan(taiKhoan);
            return CreatedAtRoute("CompanyById",new { id = createdPQ_TaiKhoan.Id_TK }, createdPQ_TaiKhoan);
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
    public async Task<IActionResult> UpdatePQ_TaiKhoan(PQ_TaiKhoanForUpdateDto taiKhoan)
    {
        try
        {
            var dbCompany = await _companyRepo.GetPQ_TaiKhoan(taiKhoan.Id_TK);
            if (dbCompany == null)
                return NotFound();

            await _companyRepo.UpdatePQ_TaiKhoan(taiKhoan);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePQ_TaiKhoan(int maTK)
    {
        try
        {
            var dbCompany = await _companyRepo.GetPQ_TaiKhoan(maTK);
            if (dbCompany == null)
                return NotFound();

            await _companyRepo.DeletePQ_TaiKhoan(maTK);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}