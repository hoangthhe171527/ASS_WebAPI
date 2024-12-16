using MS.DomainLayer.Services.Interfaces;
using MS.InfrastructureLayer.Entities;
using MS.InfrastructureLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.DomainLayer.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync() => await _unitOfWork.Students.GetAllAsync();

        public async Task<Student?> GetStudentByIdAsync(int id) => await _unitOfWork.Students.GetByIdAsync(id);

        public async Task AddStudentAsync(Student Student)
        {
            await _unitOfWork.Students.AddAsync(Student);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(Student Student)
        {
            await _unitOfWork.Students.UpdateAsync(Student);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var role = await _unitOfWork.Students.GetByIdAsync(id);
            if (role != null)
            {
                await _unitOfWork.Students.DeleteAsync(role);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
