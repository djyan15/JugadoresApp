using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Jugadores.Core.Entities
{
    public class ErrorsModel
    {
        public string Property { get; set; }
        public IEnumerable<string> Error { get; set; }
    }
}
