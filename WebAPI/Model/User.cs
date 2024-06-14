using Microsoft.EntityFrameworkCore;

namespace WebAPI.Model
{
  
    public class User
    {
        public int Id { get; set; }
        public String? Lastname { get; set; }
        public String? Firstname { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }

    }
}
