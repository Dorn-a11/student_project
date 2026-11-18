using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.Models
{
    public class ApiResponse
    {
        public static IActionResult Success(object data,string message = "Success")
        {
            return new OkObjectResult(new
            {
                Success = true,
                Code = 200,
                Message = message,
                Data = data,

            });
        }

        public static IActionResult NotFound(string message = "Not found")
        {
            return new OkObjectResult(new
            {
                Success = false,
                Code = 404,
                Message = message,
                Data = new {},

            });
        }
    }
}
