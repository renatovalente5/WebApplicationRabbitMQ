using System.Runtime.Serialization;
using WebApplicationRabbitMQ.Models;

namespace WebApplicationRabbitMQ.Data.Entities
{
    public class InviteEnum
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Friend> Friends { get; set; } = new List<Friend>();
    }

    public enum InviteEnumValues : int
    {
        [EnumMember(Value = "Pending")]
        Pending = 1,
        [EnumMember(Value = "Accepted")]
        Accepted = 2,
        [EnumMember(Value = "Declined")]
        Declined = 3
    }
}
