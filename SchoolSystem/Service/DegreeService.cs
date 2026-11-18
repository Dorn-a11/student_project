using AutoMapper;
using SchoolManagementSystem.AppExceptions;
using SchoolSystem.Dtos;
using SchoolSystem.Dtos.Request;
using SchoolSystem.Dtos.Response;
using SchoolSystem.Models;
using SchoolSystem.Repository.Interface;
using SchoolSystem.Service.Interface;

namespace SchoolSystem.Service
{
    public class DegreeService:IDegreeService
    {
        private readonly IDegreeRepository _degreeRepository;
        private readonly IMapper _mapper;
        public DegreeService(IDegreeRepository degreeRepository, IMapper mapper)
        {
            this._degreeRepository = degreeRepository;
            this._mapper = mapper;
        }


   

        //========= Get By ID ========
        public async Task<DegreeDto?> GetById(int id)
        {
            var degree = await _degreeRepository.GetById(id);
            if (degree == null)
            {
                return null;
            }
            return _mapper.Map<DegreeDto>(degree);
        }



        //========= Save Change ========
        public async Task<DegreeDto> SaveChange(DegreeDto request)
        {
            Degree degree;
            if (request == null)
            {
                throw new BadRequestException("Degree Null");
            }
            if (request.Id == 0)
            {
                degree = new Degree();

                degree.NameEnglish = request.NameEnglish;
                degree.NameKhmer = request.NameKhmer;

                await _degreeRepository.Create(degree);
            }
            else
            {
                degree = await _degreeRepository.GetById(request.Id);

                if (degree == null)
                {
                    throw new BadRequestException("Degree Not Found.");
                }

                degree.NameEnglish = request.NameEnglish;
                degree.NameKhmer = request.NameKhmer;

                await _degreeRepository.Update(degree);
            }

            return _mapper.Map<DegreeDto>(degree);
        }


        //=========== Delete =========
        public async Task<DegreeDto> Delete(int id)
        {
            var degree = await _degreeRepository.GetById(id);
            if (degree == null)
            {
                throw new BadRequestException("Degree not found.");
            }

            var deleteData = _degreeRepository.Delete(degree);
            return _mapper.Map<DegreeDto>(degree);


        }



        public async Task<DataTableResponse<DegreeDto>> GetByPageAsync(DataTableRequest request)
        {
            var result = await _degreeRepository.GetByPageAsync(request);

            return new DataTableResponse<DegreeDto>
            {
                Draw = result.Draw,
                RecordsTotal = result.RecordsTotal,
                RecordsFiltered = result.RecordsFiltered,
                Data = _mapper.Map<List<DegreeDto>>(result.Data)
            };
        }

        public Task<List<DegreeDto>> GetAllDegreeAsynce()
        {
            throw new NotImplementedException();
        }
    }
}
