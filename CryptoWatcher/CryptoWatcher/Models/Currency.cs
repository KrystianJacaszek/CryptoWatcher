using Newtonsoft.Json;

namespace CryptoWatcher.Models
{
    public class Currency
    {
        [JsonConstructor]
        public Currency(int id, string imageUrl, string name, string fullName)
        {
            this.Id = id;
            this.ImageUrl = imageUrl;
            this.Name = name;
            this.FullName = fullName;
        }
        public int Id { get; }
        public string ImageUrl { get; }
        public string Name { get; }
        public string FullName { get; }
    }
}
