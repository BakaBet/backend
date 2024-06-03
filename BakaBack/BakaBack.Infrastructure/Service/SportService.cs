using BakaBack.Domain.Models;
using Newtonsoft.Json.Linq;
using BakaBack.Infrastructure.Contexts;
using Microsoft.Extensions.Configuration;

namespace BakaBack.In.Services
{
    public class SportsOddsService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private readonly Dictionary<string, string> _endpoints;
        private readonly ApplicationDbContext _dbContext;
        private readonly string _startURI;

        public SportsOddsService(IConfiguration config, HttpClient client, ApplicationDbContext dbContext)
        {
            _client = client;
            _apiKey = config["SportsOddsApi:ApiKey"];
            _dbContext = dbContext;
            _startURI = "https://api.the-odds-api.com/v4/sports/";

            _endpoints = new Dictionary<string, string>
            {
               //{ "Ligue1", _startURI+"soccer_france_ligue_one/odds/" },
               //{ "PremierLeague", _startURI+"soccer_epl/odds/" },
               //{ "LaLiga", _startURI+"soccer_spain_la_liga/odds/" },
               //{ "Bundesliga", _startURI+ "soccer_germany_bundesliga/odds/" },
               //{ "NBA", _startURI+"basketball_nba/odds/" },
               //{ "EuroLeague", _startURI+"basketball_euroleague/odds/" },
               //{ "ATP", _startURI+"tennis_atp/odds/" },
               //{ "WTA", _startURI+"tennis_wta/odds/" },
               //{ "MLB", _startURI+"baseball_mlb/odds/" },
               //{ "NHL", _startURI+"icehockey_nhl/odds/" },
               //{ "NRL", _startURI+"rugby_league_nrl/odds/" },
               //{ "SixNations", _startURI+"rugby_union_six_nations/odds/" },
               { "NFL", _startURI+"americanfootball_nfl/odds/" },
            };
        }

        public async Task GetAndSaveMatchesAsync()
        {
            foreach (var endpoint in _endpoints)
            {
                var requestUrl = $"{endpoint.Value}?apiKey={_apiKey}&regions=eu&markets=h2h";

                var response = await _client.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var matches = JArray.Parse(responseBody);

                foreach (var match in matches)
                {
                    Match newMatch = new Match
                    {
                        Id = match["id"].ToString(),
                        SportKey = match["sport_key"].ToString(),
                        CommenceTime = DateTime.Parse(match["commence_time"].ToString()),
                        HomeTeam = match["home_team"].ToString(),
                        AwayTeam = match["away_team"].ToString(),
                        Outcomes = new List<Outcome>()
                    };

                    if (match["bookmakers"] != null && match["bookmakers"].Count() > 0 && match["bookmakers"][0]["markets"] != null && match["bookmakers"][0]["markets"].Count() > 0 && match["bookmakers"][0]["markets"][0]["outcomes"] != null)
                    {
                        var MatchOutcomes = match["bookmakers"][0]["markets"][0]["outcomes"];
                        foreach (var outcome in MatchOutcomes)
                        {
                            newMatch.Outcomes.Add(new Outcome
                            {
                                Name = outcome["name"].ToString(),
                                Price = decimal.Parse(outcome["price"].ToString())
                            });
                        }
                    }

                    _dbContext.Matches.Add(newMatch);
                }
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}