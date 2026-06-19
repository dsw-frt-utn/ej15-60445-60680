using Dsw2026Ej15.Api.Models;
using Dsw2026Ej15.Domain.Entities;
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
    public async Task<ActionResult> CreateDoctor([FromBody]DoctorModel.Request request)//si no tengo nada definido en el metodo, cuando ejecuto viene vacio
    {
        //metodo para la logica para validaciones
        if(string.IsNullOrWhiteSpace(request.Name) ||
                string.IsNullOrWhiteSpace(request.LicenseNumber))
        {
            return BadRequest("Nombre y matricula son requeridos");
        }

        var speciality = _persistence.GetSpecialityById(request.SpecialityId);

        if (speciality == null)
        { 
            return BadRequest("Especialidad no existe");
        }

        var doctor = new Doctor(request.Name, request.LicenseNumber, speciality);
        _persistence.SaveDoctor(doctor);
            return Ok(); 
    }
}}
