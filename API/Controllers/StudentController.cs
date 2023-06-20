using Application.Queries.StudentQueries;
using Application.Queries.StudentQueries.GetAllStudents;
using AutoWrapper.Wrappers;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StudentController : BaseController
    {
        [HttpGet]
        public async Task<ApiResponse> GetAllAsync([FromQuery] StudentFilterParameters filterParameters, [FromQuery] PagingParameters pagingParameters)
        {
            var result = await Mediator.Send(new GetAllStudentsQuery(new GetAllStudentsRequest()
            {
                FilterParameters = filterParameters,
                PagingParameters = pagingParameters
            }));

            return new ApiResponse(result);
        }
    }
}
