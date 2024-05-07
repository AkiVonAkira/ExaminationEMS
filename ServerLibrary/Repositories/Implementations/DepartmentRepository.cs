using BaseLibrary.Models;
using BaseLibrary.Responses;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repositories.Implementations
{
    public class DepartmentRepository(ApplicationDbContext applicationDbContext) : IGenericRepositoryInterface<Department>
    {
        public Task<GeneralResponse> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Department>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse> Insert(Department item)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse> Update(Department item)
        {
            throw new NotImplementedException();
        }
    }
}
