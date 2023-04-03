using FluentValidation;
using TodoListMinimalAPI.Data;
using TodoListMinimalAPI.Helpers;

namespace TodoListMinimalAPI.Validators
{
    public class TaskValidator : AbstractValidator<TaskModel>
    {
        public TaskValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop; //Está continuando mesmo depois da primeira falha.
            RuleFor(t => t.Title).NotEmpty().Length(2,50).NotEqual("string");
            RuleFor(t => t.Subject).NotEmpty().NotEqual("string");//.Must(ValidSubject);
            RuleFor(t => t.Description).NotEmpty().MaximumLength(140).NotEqual("string");
            RuleFor(t => t.DueDate).GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now)).WithMessage("The due date must be grater than today"); //No metodo PUT a data não esta validando
            RuleFor(t => t.Grade).InclusiveBetween(0, 10).WithMessage("The grade must be between 0 and 10");
        }

        /*protected bool ValidSubject(string subject)
        {
            List<string> validSubjects = new()
            {
                "math", "english"
            };

            return validSubjects.Any(s => s == subject.ToLower());
        }*/

        public static List<string> Valid(TaskModel response)
        {
            List<string> errorList = new();
            TaskValidator validator = new();

            var results = validator.Validate(response);

            if(results.IsValid == false)
            {
                foreach(var failure in results.Errors)
                {
                    errorList.Add($"{failure.PropertyName}: {failure.ErrorMessage}");
                }
            }
            return errorList;

        }
        //Estou retornando uma lista e tratando esse retorno no mapPost.
    }
}
