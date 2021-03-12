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

            sbDocumentation.Append("<html>");


            sbDocumentation.Append("<head>");
            sbDocumentation.Append("<meta charset = \"utf -8\" >");

            sbDocumentation.Append("<meta http - equiv = \"X -UA-Compatible\" content = \"IE=edge\" >");

            sbDocumentation.Append("<title>Help for Fuego de Quasar</titl>");

            sbDocumentation.Append("<meta name =\"description\" content = \"\" >");

            sbDocumentation.Append("< meta name = \"viewport\" content = \"width=device-width, initial-scale=1\" >");

            sbDocumentation.Append("< link rel = \"stylesheet\" href = \"\" >");

            sbDocumentation.Append("</ head >");
            sbDocumentation.Append("<body>");

            sbDocumentation.Append("<h1>Ayuda para \"Fuego de Quasar\"</h1>");

            sbDocumentation.Append("<p><strong>Aplicacion creada en C# .NET Core.</strong>></p>");
            sbDocumentation.Append("<p>Para resolver el problema de la posicion de la nave utilice los calculos de Trilateration. Para mas informacion acerca del calculo: https://es.wikipedia.org/wiki/Trilateraci%C3%B3n</p>");
            sbDocumentation.Append("<p>Es una API. Debajo van a a encontrar informacion necesaria para poder usarla</p>");
            sbDocumentation.Append("<hr>");
            sbDocumentation.Append("<p><strong>Repository: </strong>https://github.com/Paskual86/fuegodequasar-netcore.git</p>");
            sbDocumentation.Append("<p><strong>Swagger: </strong>https://fuegodequasar.us-east-2.elasticbeanstalk.com/swagger/index.html</p>");

            sbDocumentation.Append("</body>");

                             sbDocumentation.Append("</html>");
            return Ok($" Fuego de Quasar API is running...");
        }
    }
}
