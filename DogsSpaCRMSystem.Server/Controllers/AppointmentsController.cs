using DogsSpaCRMSystem.Server.Data;
using DogsSpaCRMSystem.Server.Intefrace;
using DogsSpaCRMSystem.Server.Model;
using DogsSpaCRMSystem.Server.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace DogsSpaCRMSystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointment;

        public AppointmentsController(IAppointmentService appointment)
        {
            _appointment = appointment;
        }

        // List appointments action
        [HttpGet("GetAllAppointments")]
        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {


            return await _appointment.GetAppointments();
        }

        // Create appointment action
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            // Create appointment
            await _appointment.CreateAppointment(appointment);
            return CreatedAtRoute("GetAppointment", new { id = appointment.Id }, appointment);
            // CreatedAtRoute for returning 201 Created status with location of the created resource
        }


        [HttpPut("{id}")] // Specify route with ID parameter
        public async Task<IActionResult> Update(int id, [FromBody] object jsonData)
        {

            //
            try
            { 
                // Process the JSON string or convert it to a specific class if needed
                var updatedAppointment = JsonConvert.DeserializeObject<Appointment>(jsonData.ToString());

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id == null)
                {
                    return BadRequest("NullIDErr");
                }
                // Check if the provided ID matches the ID in the object
                if (id != updatedAppointment.Id)
                {
                    return BadRequest("MisMatchIDErr");
                }

                // Retrieve the existing member from the repository
                var existingAppointment = await _appointment.GetAppointmentById(id);

                // Check if the member exists
                if (existingAppointment == null)
                {
                    return NotFound("NotFound");
                }

                // Update the properties of the existing member
                existingAppointment.ArrivalTime = updatedAppointment.ArrivalTime;
                // Save the changes to the repository
                await _appointment.UpdateAppointment(existingAppointment);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "InternalError");
            }
        }

        [HttpDelete("{id}")] // Specify route with ID parameter
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _appointment.DeleteAppointment(id);
                return NoContent(); // Indicate successful deletion without content
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log the error, return a specific error response)
                return StatusCode(500, ex.Message); // Internal Server Error with message
            }
        }

    }
}
