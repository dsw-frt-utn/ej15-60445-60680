using Dsw2026Ej15.Api.Models;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Exceptions;
using Dsw2026Ej15.Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace Dsw2026Ej15.Api.Controllers;

[ApiController]
[Route("api/doctors")]//nombre de ruta del endpoint
public class DoctorController : ControllerBase
{
    //inyectamos 
    private readonly IPersistence _persistence;
    public DoctorController(IPersistence persistence)
    {
        _persistence = persistence;
    }

    [HttpPost]//verbo
    public async Task<ActionResult> CreateDoctor([FromBody] DoctorModel.Request request)//si no tengo nada definido en el metodo, cuando ejecuto viene vacio
    {
        //metodo para la logica para validaciones
        if (string.IsNullOrWhiteSpace(request.Name) ||
                string.IsNullOrWhiteSpace(request.LicenseNumber))
        {
            throw new ValidationException("Nombre y matricula son requeridos");
        }

        var speciality = _persistence.GetSpecialityById(request.SpecialityId);

        if (speciality == null)
        {
            throw new ValidationException("Especialidad no existe");
        }

        var doctor = new Doctor(request.Name, request.LicenseNumber, speciality);
        _persistence.SaveDoctor(doctor);
        return Created();

    }
    //segundo endpoint
    [HttpGet]
    public async Task<ActionResult> GetDoctors()
    {
        var doctors = _persistence
            .GetAllDoctors()
            .Where(d => d.IsActive);

        return Ok(doctors);
    }

    [HttpGet("{id}")]
    public ActionResult GetDoctorById(Guid id)
    {
        var doctor = _persistence.GetDoctorById(id);

        if (doctor == null)
        {
            return NotFound("No se contro el medico o no esta activo");
        }

        var response = new DoctorModel.Response(
            doctor.Name, doctor.LicenseNumber, doctor.Speciality?.Name);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteDoctorById(Guid id)
    {
        var doctor = _persistence.GetDoctorById(id);

        if (doctor == null)
        {
            return NotFound("No se contro el medico o no esta activo");
        }

        doctor.IsActive = false;
        _persistence.SaveDoctor(doctor); 
        return NoContent();
    }

}