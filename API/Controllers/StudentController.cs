using Application.Commands.StudentCommands.CreateStudent;
using Application.Commands.StudentCommands.DeleteStudent;
using Application.Commands.StudentCommands.UpdateStudent;
using Application.Queries.StudentQueries;
using Application.Queries.StudentQueries.GetAllStudents;
using AutoWrapper.Extensions;
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
        [HttpPost]
        public async Task<ApiResponse> CreateAsync([FromBody] CreateStudentRequest request)
        {
            if (!ModelState.IsValid)
                throw new ApiException(ModelState.AllErrors());

            var result = await Mediator.Send(new CreateStudentCommand(request));

            return new ApiResponse(result);
        }
        [HttpPut]
        public async Task<ApiResponse> UpdateAsync(UpdateStudentRequest request)
        {
            if (!ModelState.IsValid)
                throw new ApiException(ModelState.AllErrors());

            var result = await Mediator.Send(new UpdateStudentCommand(new UpdateStudentRequest()
            {
                Id = request.Id,
                FullName = request.FullName,
                Average = request.Average,
                DateOfBirth= request.DateOfBirth,
            }));

            return new ApiResponse(result.Response);
        }
        [HttpDelete("{id}")]
        public async Task<ApiResponse> DeleteAsync(string id)
        {
            if (!ModelState.IsValid)
                throw new ApiException(ModelState.AllErrors());

            var result = await Mediator.Send(new DeleteStudentCommand(new DeleteStudentRequest()
            {
                Id = id,
            }));

            return new ApiResponse(result);
        }
    }
}
