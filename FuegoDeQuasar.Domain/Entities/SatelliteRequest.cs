namespace FuegoDeQuasar.Domain.Entities
{
    public class SatelliteRequest
    {
        public string Name { get; set; }
        public decimal Distance { get; set; }
        public string[] Message { get; set; }
    }    
}
