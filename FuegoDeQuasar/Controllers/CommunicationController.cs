using AutoMapper;
using FuegoDeQuasar.Domain.Entities;
using FuegoDeQuasar.Domain.Interfaces;
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
        private readonly ICommunicationBusiness _communicationBusiness;
        private readonly IMapper _mapper;

        public CommunicationController(ICommunicationBusiness communicationBusiness, IMapper mapper)
        {
            _communicationBusiness = communicationBusiness;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("topsecret")]
        public async Task<IActionResult> TopSecret(RequestDto payload)
        {
            if (payload == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_communicationBusiness.GetMessage(_mapper.Map<List<SatelliteRequest>>(payload.Satellites), out SatelliteResponse response)) 
                return BadRequest();

            return Ok(_mapper.Map<SatelliteResponseDto>(response));
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

            RequestDto request = new RequestDto
            {
                Satellites = new List<SatelliteRequestDto>
            {
                new SatelliteRequestDto()
                {
                    Distance = payload.Distance,
                    Message = payload.Message,
                    Name = satellite_name
                }
            }
            };

            if (!_communicationBusiness.GetMessage(_mapper.Map<List<SatelliteRequest>>(request.Satellites), out SatelliteResponse response))
                return BadRequest();
            
            // Response Ok 200 + La respuesta
            // Response Error 404 => En caso que no se pueda determinar la posición o el mensaje, retorna:

            return Ok(_mapper.Map<SatelliteResponseDto>(response));
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
