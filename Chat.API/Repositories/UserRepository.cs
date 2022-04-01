using Chat.API.Models;

namespace Chat.API.Repositories
{
    public static class UserRepository
    {
        public static User? Get(string username, string password)
        {
            var users = new List<User>();
            
            users.Add(new User() { Id = 1, Username = "Ricardo", Password = "123", Role = "Admin"});
            
            users.Add(new User() { Id = 2, Username = "Naruto", Password = "123", Role = "Tester"});
            
            return users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == password);
        }
    }
}
