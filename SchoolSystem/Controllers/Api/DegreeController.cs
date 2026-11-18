using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Dtos;
using SchoolSystem.Dtos.Request;
using SchoolSystem.Service.Interface;

namespace SchoolSystem.Controllers.Api
{
    [Route("api/[controller]")]//api/Degree/delete/1
    [ApiController]
    public class DegreeController : ControllerBase
    {
        private readonly IDegreeService _degreeService;
        public DegreeController(IDegreeService degreeService)
        {
            _degreeService = degreeService;
        }

        [HttpPost("paging")]
        public async Task<IActionResult> GetDegree()
        {
            try
            {

                var request = new DataTableRequest();

                request.Draw = Convert.ToInt32(Request.Form["draw"]);
                request.Start = Convert.ToInt32(Request.Form["start"]);
                request.Length = Convert.ToInt32(Request.Form["length"]);
                request.Search = Request.Form["search[value]"].FirstOrDefault();

                var data = await _degreeService.GetByPageAsync(request);

                return new JsonResult(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return StatusCode(500, new
                {
                    data = new { },
                    status = new
                    {
                        code = "500",
                        message = e.Message
                    }
                });

            }


        }

        [HttpPost("save-change")]
        public async Task<IActionResult> SaveChange([FromForm] DegreeDto degreeDto)
        {
            try
            {
                var exisData = await _degreeService.SaveChange(degreeDto);
                return Ok(exisData);

            }
            catch (Exception ex)

            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });


            }


        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Detete(int id)
        {
            try
            {
                var deleteData =await _degreeService.Delete(id);
                return Ok(deleteData);
            }catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });
            }
        }


    }
}



//Jquery -> Api Controller -> DegreeService -> DegreeRepository -> ApplicationDbContext(Database)