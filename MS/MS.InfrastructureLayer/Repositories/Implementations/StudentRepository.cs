using MS.InfrastructureLayer.Context;
using MS.InfrastructureLayer.Entities;
using MS.InfrastructureLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.InfrastructureLayer.Repositories.Implementations
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(MSContext context) : base(context)
        {
        }
    }
}
