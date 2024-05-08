using DogsSpaCRMSystem.Server.Intefrace;
using DogsSpaCRMSystem.Server.Model;
using MessagePack.Formatters;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DogsSpaCRMSystem.Server.Data
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IRepository<Appointment> _repository;

        public AppointmentRepository(IRepository<Appointment> repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<Appointment>> GetUserAppointments(int userId)
        {
            return await _repository.Search(x => x.UserId == userId);
        }
        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _repository.GetAll();
        }

        public async Task<IEnumerable<Appointment>> Search(Expression<Func<Appointment, bool>> predicate)
        {
            return await _repository.Search(predicate);

        }

        public async Task CreateAppointment(Appointment appointment)
        {
            await _repository.Add(appointment);
        }

        public async Task UpdateAppointment(int id, Appointment appointment)
        {
            var existingAppointment = await GetAppointmentById(id);
            if (existingAppointment != null)
            {
                existingAppointment.ArrivalTime = appointment.ArrivalTime;
                // Update other properties as needed
                await _repository.Update(appointment);
            }
        }

        public async Task DeleteAppointment(int id)
        {
            await _repository.Delete(id);
        }

    }

}
