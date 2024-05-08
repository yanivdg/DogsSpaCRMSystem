using DogsSpaCRMSystem.Server.Model;
using System.Linq.Expressions;

namespace DogsSpaCRMSystem.Server.Intefrace
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointmentById(int id);
        Task<IEnumerable<Appointment>> GetUserAppointments(int userId);
        Task<IEnumerable<Appointment>> SearchAppointments(Expression<Func<Appointment, bool>> predicate);
        Task<Appointment> CreateAppointment(Appointment appointment);
        Task UpdateAppointment(Appointment appointment);
        Task DeleteAppointment(int id);
    }

}
