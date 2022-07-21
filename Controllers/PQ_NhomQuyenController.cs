using Microsoft.AspNetCore.Components;
namespace ASP.NET8.Controllers;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


[Route("api/PQ_NhomQuyen")]
[ApiController]
public class PQ_NhomQuyenController : ControllerBase
{
    private readonly IPQ_NhomQuyenRepository _taisanRepo;

    public PQ_NhomQuyenController(IPQ_NhomQuyenRepository taisanRepo)
    {
        _taisanRepo = taisanRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetPQ_NhomQuyen()
    {
        try
        {
            var compan = await _taisanRepo.GetPQ_NhomQuyen();
            return Ok(compan);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    /*[HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetPQ_NhomQuyen(int maTK)
    {
        try
        {
            var company = await _companyRepo.GetPQ_NhomQuyen(maTK);
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
            var company = await _companyRepo.GetPQ_NhomQuyenByPQ_NhomQuyen_TKid(id);
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
    public async Task<IActionResult> GetPQ_NhomQuyenPQ_NhomQuyen_TKMultipleMapping()
    {
        try
        {
            var company = await _companyRepo.GetPQ_NhomQuyenPQ_NhomQuyen_TKMultipleMapping();

            return Ok(company);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }*/

    [HttpPost]
    public async Task<IActionResult> CreatePQ_NhomQuyen(PQ_NhomQuyenForCreationDto nhomQuyen)
    {
        try
        {
            var createdPQ_NhomQuyen = await _taisanRepo.CreatePQ_NhomQuyen(nhomQuyen);
            return CreatedAtRoute("CompanyById",new { id = createdPQ_NhomQuyen.Id_NQ }, createdPQ_NhomQuyen);
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
    public async Task<IActionResult> UpdatePQ_NhomQuyen(PQ_NhomQuyenForUpdateDto nhomQuyen)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetPQ_NhomQuyen(nhomQuyen.Id_NQ);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.UpdatePQ_NhomQuyen(nhomQuyen);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePQ_NhomQuyen(int Id_NQ)
    {
        try
        {
            var dbCompany = await _taisanRepo.GetPQ_NhomQuyen(Id_NQ);
            if (dbCompany == null)
                return NotFound();

            await _taisanRepo.DeletePQ_NhomQuyen(Id_NQ);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}