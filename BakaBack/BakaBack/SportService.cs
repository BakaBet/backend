using Newtonsoft.Json.Linq;

namespace BakaBack
{
    public class SportsOddsService
    {
        private readonly string _apiKey;
        private readonly Dictionary<string, string> _endpoints;
        private HttpClient client = new HttpClient();

        private string startURI = "https://api.the-odds-api.com/v4/sports/";
        private static readonly string apiKey = "62a9e964acb1b087bfc057fe3f07947d";

        public SportsOddsService()
        {
            _endpoints = new Dictionary<string, string>
            {
                { "Ligue1", startURI+"soccer_france_ligue_one/odds/" },
                { "PremierLeague", startURI+"soccer_epl/odds/" },
                { "LaLiga", startURI+"soccer_spain_la_liga/odds/" },
                { "Bundesliga", startURI+ "soccer_germany_bundesliga/odds/" },
                { "NBA", startURI+"basketball_nba/odds/" },
                { "EuroLeague", startURI+"basketball_euroleague/odds/" },
                { "ATP", startURI+"tennis_atp/odds/" },
                { "WTA", startURI+"tennis_wta/odds/" },
                { "MLB", startURI+"baseball_mlb/odds/" },
                { "NHL", startURI+"icehockey_nhl/odds/" },
                { "NRL", startURI+"rugby_league_nrl/odds/" },
                { "SixNations", startURI+"rugby_union_six_nations/odds/" },
                { "NFL", startURI+"americanfootball_nfl/odds/" },
            };
        }

        public string CreateURI(string sportKey)
        {
            if (!_endpoints.ContainsKey(sportKey))
                throw new ArgumentException("Invalid sport key");

            string endpoint = _endpoints[sportKey];
            string requestUrl = $"{startURI}{endpoint}?apiKey={_apiKey}&regions=eu&markets=h2h";

            return requestUrl;
        }

        public async Task<JArray> GetOddsAsync(string sportKey)
        {
            HttpResponseMessage response = await client.GetAsync(CreateURI(sportKey));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JArray.Parse(responseBody);
        }
    }
}
