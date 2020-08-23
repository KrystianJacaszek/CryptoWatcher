using Newtonsoft.Json;

namespace API.Models
{
    public class Currency
    {
        public int Id { get; }
        public string ImageUrl { get; }
        public string Name {get;}
        public string FullName { get; }
        
        [JsonConstructor]
        public Currency(int id, string imageUrl, string name, string fullName)
        {
            this.Id = id;
            this.ImageUrl = imageUrl;
            this.Name = name;
            this.FullName = fullName;
        }
    }
}
