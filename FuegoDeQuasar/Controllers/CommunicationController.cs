using FuegoDeQuasar.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuegoDeQuasar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        [HttpPost("topsecret")]
        public async Task<IActionResult> TopSecret(List<SatelliteRequestDto> payload)
        {
            if (payload == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Response Ok 200 + La respuesta
            // Response Error 404 => En caso que no se pueda determinar la posición o el mensaje, retorna:
            var value = payload.FirstOrDefault();

            var model = new SatelliteResponseDto
            {
                Message = (payload.FirstOrDefault() != null) ? $"There is are {value.Message.Length.ToString()} messages" : "There is not messages"
            };
            return Ok(new SatelliteResponseDto());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="satellite_name"></param>
        /// <returns></returns>
        [HttpPost("topsecret_split/{satellite_name}")]
        public async Task<IActionResult> TopSecretSplit([FromBody]SatelliteRequestDto payload, [FromRoute] string satellite_name)
        {
            if (payload == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = new SatelliteResponseDto
            {
                Message = satellite_name
            };
            // Response Ok 200 + La respuesta
            // Response Error 404 => En caso que no se pueda determinar la posición o el mensaje, retorna:

            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="satellite_name"></param>
        /// <returns></returns>
        [HttpGet("topsecret_split/{satellite_name}")]
        public async Task<IActionResult> TopSecretSplitGet(string satellite_name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Response Ok 200 + La respuesta
            // Response Error 404 => En caso que no se pueda determinar la posición o el mensaje, retorna:

            var response = new SatelliteResponseDto
            {
                Message = satellite_name
            };

            return Ok(response);
        }
    }
}
