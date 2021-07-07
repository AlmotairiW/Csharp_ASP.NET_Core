using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class UserWedding
    {
        [Key]
        public int UserWeddingId {set;get;}

        public int UserId { get; set; }
        public int WeddingId {set;get;}

        public User GuestOnWedding {set;get;}
        public Wedding WeddingOfGuest {set;get;}

    }
}