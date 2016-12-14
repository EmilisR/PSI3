using Newtonsoft.Json;

namespace Festofilas.Models.JsonModels
{
    public class Location
    {
        public string PlainTextAddress { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void Populate(string json)
        {
            JsonConvert.PopulateObject(json, this);
        }
    }
}