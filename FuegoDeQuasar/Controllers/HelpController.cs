using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FuegoDeQuasar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            StringBuilder sbDocumentation = new StringBuilder();

            sbDocumentation.Append("<h1>Ayuda para \"Fuego de Quasar\"</h1>");

            sbDocumentation.Append("<p><strong>Aplicacion creada en C# .NET Core.</strong>></p>");
            sbDocumentation.Append("<p>Para resolver el problema de la posicion de la nave utilice los calculos de Trilateration. Para mas informacion acerca del calculo: https://es.wikipedia.org/wiki/Trilateraci%C3%B3n</p>");
            sbDocumentation.Append("<p>Es una API. Debajo van a a encontrar informacion necesaria para poder usarla</p>");
            sbDocumentation.Append("<hr>");
            sbDocumentation.Append("<p><strong>Repository: </strong><a href=\"https://github.com/Paskual86/fuegodequasar-netcore.git\">GIT</a></p>");
            sbDocumentation.Append("<p><strong>Swagger: </strong> <a href=\"https://fuegodequasar.us-east-2.elasticbeanstalk.com/swagger/index.html\">SWAGGER</a></p>");

            return base.Content(sbDocumentation.ToString(), "text/html"); 
        }
    }
}
