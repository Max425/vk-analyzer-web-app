using Microsoft.EntityFrameworkCore;

namespace DataBaseModels
{
    [PrimaryKey("Id")]
    public class CommunityUser
    {
        public int Id { get; set; }
        public Community CommunityId { get; set; }
        public UserAccount UserAccountId { get; set; }

        public CommunityUser() { }

        public override string ToString() => $"Chain {CommunityId.Id} - {UserAccountId.Id}";
    }
}