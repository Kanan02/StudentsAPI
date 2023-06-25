using Application.Commands.StudentCommands.UpdateStudent;
using Core.Constants;
using FluentValidation;


namespace Application.Validators.StudentValidators
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudentRequest>
    {
        public UpdateStudentValidator()
        {
            RuleFor(student => student.FullName).NotNull().NotEmpty().Length(1, StringLengthConstants.LengthLg);

            RuleFor(student => student.Average).NotNull().InclusiveBetween(0, 20).WithMessage("The average grade shoulde be between 0 and 20 inclusively");

            RuleFor(student => student.DateOfBirth).NotNull().NotEmpty();
        }
    }
}
