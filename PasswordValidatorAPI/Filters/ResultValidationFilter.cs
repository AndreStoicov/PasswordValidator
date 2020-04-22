using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using PasswordValidatorAPI.Models;

namespace PasswordValidatorAPI.Filters
{
    public class ResultValidationFilter : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Keys.SelectMany(key => context.ModelState[key].Errors.Select(x =>
                    new DomainValidationError
                    {
                        Type = key,
                        Message = x.ErrorMessage
                    })).ToList();

                var response = new ResponsePassword(false) {Errors = errors};
                var objectError = new ObjectResult(response) {StatusCode = StatusCodes.Status422UnprocessableEntity};
                context.Result = objectError;
            }

            base.OnResultExecuting(context);
        }
    }
}