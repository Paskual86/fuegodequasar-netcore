using FuegoDeQuasar.Domain.Entities;
using FuegoDeQuasar.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FuegoDeQuasar.Core.Business
{
    public class CommunicationBusiness : ICommunicationBusiness
    {
        private readonly ITrilaterationOperation _trilaterationOperation;
        private readonly IMessageOperation _messageOperation;

        public CommunicationBusiness(ITrilaterationOperation trilaterationOperation, IMessageOperation messageOperation)
        {
            _trilaterationOperation = trilaterationOperation;
            _messageOperation = messageOperation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public bool GetMessage(List<SatelliteRequest> payload, out SatelliteResponse response)
        {
            response = new SatelliteResponse
            {
                Position = _trilaterationOperation.GetLocation(GetKenobiDistance(payload), GetSkywalkerDistance(payload), GetSatoDistance(payload)),
                Message = _messageOperation.GetMessage(GetMessages(payload))
            };

            return ((response.Position != null)&&(response.Message.Trim().Length != 0));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        private decimal? GetKenobiDistance(List<SatelliteRequest> payload)
        {
            return GetDistance(payload, "kenobi");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        private decimal? GetSkywalkerDistance(List<SatelliteRequest> payload)
        {
            return GetDistance(payload, "kywalker");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        private decimal? GetSatoDistance(List<SatelliteRequest> payload)
        {
            return GetDistance(payload, "sato");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="satelliteName"></param>
        /// <returns></returns>
        private decimal? GetDistance(List<SatelliteRequest> payload, string satelliteName)
        {
            var satellite = GetSatellite(payload, satelliteName);
            if (satellite == null) return null;
            return satellite.Distance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="satelliteName"></param>
        /// <returns></returns>
        private SatelliteRequest GetSatellite(List<SatelliteRequest> payload, string satelliteName)
        {
            if ((payload == null) || (payload.Count == 0)) return null;
            return payload.FirstOrDefault(fo => fo.Name.Trim().ToLower() == satelliteName);
        }

        /// <summary>
        /// Get The messages
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        private IEnumerable<string[]> GetMessages(List<SatelliteRequest> payload)
        {
            if (payload == null) yield return new string[0];

            foreach (var req in payload)
            {
                yield return req.Message;
            }
        }


    }
}
