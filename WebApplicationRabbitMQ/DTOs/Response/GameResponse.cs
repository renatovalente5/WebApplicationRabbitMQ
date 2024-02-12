namespace WebApplicationRabbitMQ.DTOs.Response
{
    public class GameResponse
    {
        public int Id { get; set; }
        public DateTime Datetime { get; set; }

        public int Duration { get; set; }

        public int NumPlayers { get; set; }

        public int? Level { get; set; }

        public string? Link { get; set; }

        public int GameTypeEnumId { get; set; }

        public DateTime DbCreatedOn { get; set; }
    }
}
