using FluentValidation;
using TodoListMinimalAPI.Data;

namespace TodoListMinimalAPI.Validators;

public class TaskValidator : AbstractValidator<TaskModel>
{
    public TaskValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        RuleFor(t => t.Title).NotEmpty().Length(2, 50).NotEqual("string");
        RuleFor(t => t.Subject).NotEmpty().IsInEnum();
        RuleFor(t => t.Description).NotEmpty().MaximumLength(140).NotEqual("string");
        RuleFor(t => t.DueDate).GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now)).WithMessage("The due date must be grater than today"); //No metodo PUT a data não esta validando
        RuleFor(t => t.Grade).InclusiveBetween(0, 10).WithMessage("The grade must be between 0 and 10");
    }
   
    public static List<string> Valid(TaskModel response)
    {
        List<string> errorList = new();
        TaskValidator validator = new();

        var results = validator.Validate(response);
        //nbuilder
        if (!results.IsValid)
        {
            foreach (var failure in results.Errors)
            {
                errorList.Add($"{failure.PropertyName}: {failure.ErrorMessage}");
            }
        }
        return errorList;
        
        //testa se a validação retorna uma lista vazia de erros quando os dados são válidos.
        // testa se a validação retorna uma lista contendo a quantidade de erro corretas quando os dados são inválidos.
    }
}
