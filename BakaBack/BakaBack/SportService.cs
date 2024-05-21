using BakaBack.Models;
using Newtonsoft.Json.Linq;

namespace BakaBack
{
    public class SportsOddsService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private readonly Dictionary<string, string> _endpoints;
        private readonly SportsDbContext _dbContext;
        private readonly string _startURI;

        public SportsOddsService(IConfiguration config, HttpClient client, SportsDbContext dbContext)
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
                    var newMatch = new Match
                    {
                        // Assignez les propriétés du match à partir des données
                    };

                    _dbContext.Matches.Add(newMatch);
                }
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}