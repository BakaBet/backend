using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Match
{
    [Key]
    public string Id { get; set; }
    public string SportKey { get; set; }
    public DateTime CommenceTime { get; set; }
    public string HomeTeam { get; set; }
    public string AwayTeam { get; set; }
    public virtual ICollection<Bookmaker> Bookmakers { get; set; }
}

public class Bookmaker
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public virtual ICollection<Market> Markets { get; set; }
    public int MatchId { get; set; }
    public virtual Match Match { get; set; }
}

public class Market
{
    [Key]
    public int Id { get; set; }
    public string Key { get; set; }
    public virtual ICollection<Outcome> Outcomes { get; set; }
    public int BookmakerId { get; set; }
    public virtual Bookmaker Bookmaker { get; set; }
}

public class Outcome
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int MarketId { get; set; }
    public virtual Market Market { get; set; }
}
