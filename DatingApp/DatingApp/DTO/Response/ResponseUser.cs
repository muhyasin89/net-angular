using DatingApp.Data;

namespace DatingApp.DTO.Response
{
    public class ResponseUser
    {
        public string? Message { get; set; }
        public int Code { get; set; }
        public AppUser? user;
    }
}
