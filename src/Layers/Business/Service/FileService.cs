using Business.IService;
using Contracts.Enums;
using Domain.Entities;

namespace Business.Service
{
    public class FileService : IFileService
    {
        private readonly IPlayerService _playerService;
        private readonly ISportTypeService _sportTypeService;
        private readonly IRatingPointService _ratingPointService;
        private readonly ITeamService _teamService;
        private readonly IPlayerPositionService _playerPositionService;
        public FileService(IPlayerService playerService, ISportTypeService sportTypeService, IRatingPointService ratingPointService, ITeamService teamService, IPlayerPositionService playerPositionService)
        {
            _playerService = playerService;
            _sportTypeService = sportTypeService;
            _ratingPointService = ratingPointService;
            _teamService = teamService;
            _playerPositionService = playerPositionService;
        }
        public void GetFiles(string path)
        {
            var players = new List<Player>();
            if (File.Exists(path))
            {
                GetFileInfos(path);
            }
            if (Directory.Exists(path))
            {
                var urls = Directory.GetFiles(path);
                foreach (var url in urls)
                {
                    GetFileInfos(url);
                }
            }

        }
        public void GetFileInfos(string url)
        {
            var index = 0;
            var fixParameterCount = 5;
            var sportType = new SportType();
            var ratingPoints = new List<RatingPoint>();
            //save on finally area
            var players = new List<Player>();
            var teams = new List<Team>();
            var playerPositions = new List<PlayerPosition>();
            //
            try
            {
                using (var sr = new StreamReader(url))
                {
                    var line = "";
                    do
                    {
                        line = sr.ReadLine();
                        if (index == 0)
                        {
                            var sportTypeName = line;
                            sportType = _sportTypeService.GetSportTypesByName(sportTypeName);
                            ratingPoints = _ratingPointService.GetRatingPointsBySportTypeName(sportType?.Name);

                            if (sportType == null && ratingPoints == null)
                                line = null;
                        }

                        if (index > 0 && sportType != null && !string.IsNullOrEmpty(line))
                        {
                            var parameters = line.Split(";");
                            var player = new Player();
                            player.Name = parameters[0];
                            player.NickName = parameters[1];
                            player.Number = Convert.ToInt32(parameters[2]);


                            //Player Position
                            var playerPosition = new PlayerPosition();
                            playerPosition = _playerPositionService.GetPlayerPositionByCodeAndSportTypeName(parameters[4], sportType.Name);
                            player.PlayerPosition = playerPosition;
                            //
                            //Rating Parameters
                            var playerRatingPoints = ratingPoints.Where(rp => rp.PlayerPosition == player.PlayerPosition).ToList();
                            if (parameters.Count() == playerRatingPoints.Where(prp => prp.RatingType != RatingTypeEnum.Fixed).Count() + fixParameterCount)
                            {
                                var prpIndex = 0;
                                foreach (var item in playerRatingPoints.OrderBy(prp => prp.Order))
                                {
                                    player.RatingParameters.Add(new RatingParameter() { RatingPoint = item, Value = item.RatingType == RatingTypeEnum.Dynamic ? Convert.ToInt32(parameters[fixParameterCount + prpIndex]) : item.Point });
                                    if (item.RatingType == RatingTypeEnum.Dynamic)
                                    {
                                        prpIndex++;
                                    }


                                }
                            }
                            //
                            //team
                            var team = teams.FirstOrDefault(t => t.Name == parameters[3]);
                            if (team == null)
                                team = new Team();

                            team.Name = parameters[3];
                            team.Score += player.RatingParameters.FirstOrDefault(prp => prp.RatingPoint.Name == sportType.WinParameter).Value;
                            player.Team = team;

                            if (!teams.Any(t => t.Name == team.Name))
                                teams.Add(team);

                            //
                            players.Add(player);
                        }
                        index++;

                    } while (!string.IsNullOrEmpty(line));

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (!players.Where(p => !p.RatingParameters.Any()).Any())
                {
                    var winnerTeam = players.GroupBy(p => p.Team).Select(a => a.Key).OrderByDescending(a=>a.Score).FirstOrDefault();

                    foreach (var player in players.Where(p=>p.Team.Name == winnerTeam.Name))
                    {
                        player.RatingParameters.Where(rp=>rp.RatingPoint.Name == "Winner Score" && rp.RatingPoint.RatingType == RatingTypeEnum.Fixed).FirstOrDefault().Value = 10;
                    }
                    _playerService.AddPlayers(players);
                    _teamService.AddTeams(teams);
                
                }

            }
    

        }
    }
}
