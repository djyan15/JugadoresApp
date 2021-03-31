using Jugadores.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jugadores.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                List<ErrorsModel> errorsModel = new List<ErrorsModel>();

                context.Result = new BadRequestObjectResult(context.ModelState);
                //var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                //  //.SelectMany(v => v.Errors)
                //  //.Select(v => v.ErrorMessage)
                  //.ToList();

                // Captura el error de cada campo y lo devuelve de acuerdo al modelo de error
                foreach (var modelStateKey in context.ModelState.Keys)
                {
                    var value = context.ModelState[modelStateKey];
                   
                    errorsModel.Add(new ErrorsModel { Property = modelStateKey, Error = value.Errors.Select(v => v.ErrorMessage) });
                 
                }

    
                context.Result = new JsonResult(errorsModel)
                {
                    StatusCode = 400
                };
                return;
            }

            await next();
        }
    }
}
