using SchoolSystem.Dtos.Request;
using SchoolSystem.Dtos.Response;
using SchoolSystem.Models;

namespace SchoolSystem.Repository.Interface
{
    public interface IDegreeRepository
    {
        Task<List<Degree>> GetAllDegree();
        Task<Degree?> GetById(int id);
        Task<Degree> Create(Degree request);
        Task<Degree> Update(Degree request);
        Task<Degree> Delete(Degree request);

        Task<DataTableResponse<Degree>> GetByPageAsync(DataTableRequest request);


    }
}
