using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/PQ_TaiKhoan_DN")]
[ApiController]
public class PQ_TaiKhoan_DNController : ControllerBase
{
    private readonly IPQ_TaiKhoan_DNRepository _companyRepo;

    public PQ_TaiKhoan_DNController(IPQ_TaiKhoan_DNRepository companyRepo)
    {
        _companyRepo = companyRepo;
    }

    [HttpPost]
    public async Task<IActionResult> GetPQ_TaiKhoan_DN(PQ_TaiKhoan_DNForCreationDto nguoidung)
    {
        try
        {
            var companies = await _companyRepo.GetPQ_TaiKhoan_DN(nguoidung);
            var abc = await _companyRepo.GetPQ_TaiKhoan_DN1(nguoidung);
            if (companies == null)
                
            return Ok(abc);
            return Ok(companies);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetPQ_TaiKhoan_DN(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetPQ_TaiKhoan_DN(maTK);
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
            var company = await _companyRepo.GetPQ_TaiKhoan_DNByPQ_NhomQuyen_TKid(id);
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
    public async Task<IActionResult> GetPQ_TaiKhoan_DNPQ_NhomQuyen_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetPQ_TaiKhoan_DNPQ_NhomQuyen_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    //[HttpPost]
    //public async Task<IActionResult> CreatePQ_TaiKhoan_DN(PQ_TaiKhoan_DNForCreationDto taiKhoan)
    //{
    //    try
    //    {
    //        var createdPQ_TaiKhoan_DN = await _companyRepo.CreatePQ_TaiKhoan_DN(taiKhoan);
    //        return CreatedAtRoute("CompanyById",new { id = createdPQ_TaiKhoan_DN.Id_TK }, createdPQ_TaiKhoan_DN);
    //    }
    //    /*var createdTaiKhoan = await _companyRepo.CreateTaiKhoan(taiKhoan);
    //    return CreatedAtRoute("CompanyById", createdTaiKhoan.TenTK, createdTaiKhoan);*/
    //    catch (Exception ex)
    //    {
    //        //log error
    //        return StatusCode(500, ex.Message);
    //    }
    //}
    //[HttpPut("{id}")]
    //public async Task<IActionResult> UpdatePQ_TaiKhoan_DN(int maTK, PQ_TaiKhoan_DNForUpdateDto taiKhoan)
    //{
    //    try
    //    {
    //        var dbCompany = await _companyRepo.GetPQ_TaiKhoan_DN(maTK);
    //        if (dbCompany == null)
    //            return NotFound();

    //        await _companyRepo.UpdatePQ_TaiKhoan_DN(maTK, taiKhoan);
    //        return NoContent();
    //    }
    //    catch (Exception ex)
    //    {
    //        //log error
    //        return StatusCode(500, ex.Message);
    //    }
    //}

    //[HttpDelete]
    //public async Task<IActionResult> DeletePQ_TaiKhoan_DN(int maTK)
    //{
    //    try
    //    {
    //        var dbCompany = await _companyRepo.GetPQ_TaiKhoan_DN(maTK);
    //        if (dbCompany == null)
    //            return NotFound();

    //        await _companyRepo.DeletePQ_TaiKhoan_DN(maTK);
    //        return NoContent();
    //    }
    //    catch (Exception ex)
    //    {
    //        //log error
    //        return StatusCode(500, ex.Message);
    //    }
    //}
}