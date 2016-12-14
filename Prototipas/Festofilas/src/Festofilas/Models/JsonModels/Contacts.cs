using Newtonsoft.Json;


namespace Festofilas.Models.JsonModels
{
    public class Contacts
    {
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Facebook { get; set; }

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