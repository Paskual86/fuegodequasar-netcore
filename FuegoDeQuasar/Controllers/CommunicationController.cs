using FuegoDeQuasar.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FuegoDeQuasar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        [HttpPost]
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


            return Ok(new SatelliteResponseDto());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="satellite_name"></param>
        /// <returns></returns>
        [HttpPost("topsecret_split/{satellite_name}")]
        public async Task<IActionResult> TopSecretSplit([FromBody]SatelliteRequestDto payload, [FromHeader] string satellite_name)
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


            return Ok(new SatelliteResponseDto());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="satellite_name"></param>
        /// <returns></returns>
        [HttpGet("topsecret_split/{satellite_name}")]
        public async Task<IActionResult> GetByPhone(string satellite_name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Response Ok 200 + La respuesta
            // Response Error 404 => En caso que no se pueda determinar la posición o el mensaje, retorna:


            return Ok(new SatelliteResponseDto());
        }
    }
}
