using Azure.Core;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;
using SchoolSystem.Dtos.Request;
using SchoolSystem.Dtos.Response;
using SchoolSystem.Models;
using SchoolSystem.Repository.Interface;

namespace SchoolSystem.Repository
{
    public class DegreeRepository:IDegreeRepository
    {
        private readonly ApplicationDbContext _context;
        public DegreeRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Degree> Create(Degree request)
        {
            await _context.tblDegree.AddAsync(request);
            await _context.SaveChangesAsync();

            return request;
        }

        public async Task<Degree> Delete(Degree request)
        {
            _context.tblDegree.Remove(request);
            await _context.SaveChangesAsync();
            return request;

         
        }

        public async Task<List<Degree>> GetAllDegree()
        {
         var data=   await _context.tblDegree.ToListAsync();
            return data;

         
        }

        public async Task<Degree?> GetById(int id)//5
        {
           var data = await _context.tblDegree.FirstOrDefaultAsync(d=>d.Id==id);
            return data;
      
        }



        public async Task<Degree> Update(Degree request)
        {
            _context.tblDegree.Update(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<DataTableResponse<Degree>> GetByPageAsync(DataTableRequest request)
        {
            var query = _context.tblDegree.AsQueryable();

            var recordsTotal = await query.CountAsync();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                query = query.Where(x =>
                    x.NameEnglish!.Contains(request.Search) ||
                    x.NameKhmer!.Contains(request.Search));
            }

            var recordsFiltered = await query.CountAsync();

            var data = await query
                .OrderBy(x => x.Id)
                .Skip(request.Start)
                .Take(request.Length)
                .ToListAsync();

            return new DataTableResponse<Degree>
            {
                Draw = request.Draw,
                RecordsTotal = recordsTotal,
                RecordsFiltered = recordsFiltered,
                Data = data
            };
        }


    }
}
