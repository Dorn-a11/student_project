using SchoolSystem.Dtos;
using SchoolSystem.Dtos.Request;
using SchoolSystem.Dtos.Response;

namespace SchoolSystem.Service.Interface
{
    public interface IDegreeService
    {
        Task<List<DegreeDto>> GetAllDegreeAsynce();
        Task<DegreeDto?> GetById(int id);
        Task<DegreeDto> SaveChange(DegreeDto request);
        Task<DegreeDto> Delete(int id);
        Task<DataTableResponse<DegreeDto>> GetByPageAsync(DataTableRequest request);
    }
}
