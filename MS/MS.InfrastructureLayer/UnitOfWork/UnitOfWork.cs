using MS.InfrastructureLayer.Context;
using MS.InfrastructureLayer.Repositories.Implementations;
using MS.InfrastructureLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.InfrastructureLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MSContext _context;

        public UnitOfWork(MSContext context)
        {
            _context = context;
            Students = new StudentRepository(_context);

        }

        public IStudentRepository Students { get; }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
