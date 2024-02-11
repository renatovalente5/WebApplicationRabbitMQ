﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebApplicationRabbitMQ.Models;

public partial class Game
{
    public int Id { get; set; }

    public DateTime Datetime { get; set; }

    public int Duration { get; set; }

    public int NumPlayers { get; set; }

    public int? Level { get; set; }

    public string? Link { get; set; }

    public bool DbStatus { get; set; }

    public DateTime DbCreatedOn { get; set; }

    public byte[] RowVersion { get; set; }

    public virtual ICollection<UsersGame> UsersGames { get; set; } = new List<UsersGame>();
}