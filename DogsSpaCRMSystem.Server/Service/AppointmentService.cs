using DogsSpaCRMSystem.Server.Intefrace;
using DogsSpaCRMSystem.Server.Model;
using System.Linq.Expressions;

namespace DogsSpaCRMSystem.Server.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        // Inject other dependencies here (e.g., IUserService for user ID retrieval)

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }


        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _appointmentRepository.GetAppointmentById(id);
        }

        public async Task<IEnumerable<Appointment>> GetUserAppointments(int userId)
        {
            return await _appointmentRepository.GetUserAppointments(userId); // Assuming this exists in IAppointmentRepository
        }

        public async Task<IEnumerable<Appointment>> SearchAppointments(Expression<Func<Appointment, bool>> predicate)
        {
            return await _appointmentRepository.Search(predicate);
        }

        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {

            // Set user ID based on current user (implementation depends on your authentication mechanism)
            bool validate = await ValidateAppointment(appointment);
            if (validate)
            {
               await _appointmentRepository.CreateAppointment(appointment);
            }
            return appointment;
        }

        public async Task UpdateAppointment(Appointment appointment)
        {
            bool validate = await ValidateAppointment(appointment); 
            if(!validate)
                await _appointmentRepository.UpdateAppointment(appointment.Id, appointment);
        }

        public async Task DeleteAppointment(int id)
        {
            await _appointmentRepository.DeleteAppointment(id);
        }

        public async Task<bool> ValidateAppointment(Appointment appointment)
        {
            // Check for required fields (modify based on your model)

            // Check for date conflicts with existing appointments
            var existingAppointments = await _appointmentRepository.Search(
                a => a.UserId == appointment.UserId && a.ArrivalTime == appointment.ArrivalTime && a.Id != appointment.Id); // Exclude itself

            return !existingAppointments.Any(); // Return false if any conflicts exist
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _appointmentRepository.GetAppointments();
        }

    }
}
