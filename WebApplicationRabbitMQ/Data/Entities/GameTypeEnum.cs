using System.Runtime.Serialization;
using WebApplicationRabbitMQ.Models;

namespace WebApplicationRabbitMQ.Data.Entities
{
    public class GameTypeEnum
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; } = new List<Game>();
    }

    public enum GameTypeValues : int
    {
        [EnumMember(Value = "Public")]
        Public = 1,
        [EnumMember(Value = "OnlyFriends")]
        OnlyFriends = 2,
        [EnumMember(Value = "OnlyByInvite")]
        OnlyByInvite = 3
    }
}
