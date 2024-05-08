using DogsSpaCRMSystem.Server.Model;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;

namespace DogsSpaCRMSystem.Server.Intefrace
{
    public interface IAppointmentRepository
    {

        Task<Appointment> GetAppointmentById(int id);
        Task<IEnumerable<Appointment>> GetUserAppointments(int userId);
        Task<IEnumerable<Appointment>> Search(Expression<Func<Appointment, bool>> predicate);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task CreateAppointment(Appointment appointment);
        Task UpdateAppointment(int id, Appointment appointment);
        Task DeleteAppointment(int id);

    }

}
