using System.Text.Json.Serialization;

namespace c_sharp_jwt_auth.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        //[JsonIgnore] attribute prevents the password property from being serialized and returned in api responses
        [JsonIgnore]
        public string Password { get; set; }
    }
}
