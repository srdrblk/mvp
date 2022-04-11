using Business.IService;
using Contracts.Enums;

namespace Business.Service
{
    public class MainService : IMainService
    {
        private readonly IFileService _fileService;
        private readonly ISportTypeService _sportTypeService;
        private readonly IRatingPointService _ratingPointService;
        private readonly IPlayerPositionService _playerPositionService;
        private readonly IPlayerService _playerService;
        public MainService(IFileService fileService, ISportTypeService sportTypeService, IRatingPointService ratingPointService, IPlayerPositionService playerPositionService, IPlayerService playerService)
        {
            _fileService = fileService;
            _sportTypeService = sportTypeService;
            _ratingPointService = ratingPointService;
            _playerPositionService = playerPositionService;
            _playerService = playerService;
            Seed();

        }
        public void Seed()
        {
           var stBasketball =  _sportTypeService.AddSportType("BASKETBALL", "Scored point");

            var ppBasketballGuard =  _playerPositionService.AddPlayerPosition(stBasketball, "Guard (G)","G");
            _ratingPointService.AddRatingPoint(ppBasketballGuard,RatingTypeEnum.Dynamic, "Scored point",2,1);
            _ratingPointService.AddRatingPoint(ppBasketballGuard, RatingTypeEnum.Dynamic, "Rebound", 3,2);
            _ratingPointService.AddRatingPoint(ppBasketballGuard, RatingTypeEnum.Dynamic, "Assist", 1,3);
            _ratingPointService.AddRatingPoint(ppBasketballGuard, RatingTypeEnum.Fixed, "Winner Score", 0, 4);


            var ppBasketballForward =  _playerPositionService.AddPlayerPosition(stBasketball, "Forward (F)","F");
            _ratingPointService.AddRatingPoint(ppBasketballForward, RatingTypeEnum.Dynamic, "Scored point", 2,1);
            _ratingPointService.AddRatingPoint(ppBasketballForward, RatingTypeEnum.Dynamic, "Rebound", 2,2);
            _ratingPointService.AddRatingPoint(ppBasketballForward, RatingTypeEnum.Dynamic, "Assist", 2,3);
            _ratingPointService.AddRatingPoint(ppBasketballForward, RatingTypeEnum.Fixed, "Winner Score", 0, 4);

            var ppBasketballCenter = _playerPositionService.AddPlayerPosition(stBasketball, "Center (C)","C");
            _ratingPointService.AddRatingPoint(ppBasketballCenter, RatingTypeEnum.Dynamic, "Scored point", 2,1);
            _ratingPointService.AddRatingPoint(ppBasketballCenter, RatingTypeEnum.Dynamic, "Rebound", 1,2);
            _ratingPointService.AddRatingPoint(ppBasketballCenter, RatingTypeEnum.Dynamic, "Assist", 3,3);
            _ratingPointService.AddRatingPoint(ppBasketballCenter, RatingTypeEnum.Fixed, "Winner Score", 0, 4);
             
            var stHandball = _sportTypeService.AddSportType("HANDBALL", "Goal made");

            var ppHandballGoalkeeper = _playerPositionService.AddPlayerPosition(stHandball, "Goalkeeper (G)", "G");
            _ratingPointService.AddRatingPoint(ppHandballGoalkeeper, RatingTypeEnum.Fixed, "Initial rating points", 50, 1);
            _ratingPointService.AddRatingPoint(ppHandballGoalkeeper, RatingTypeEnum.Dynamic, "Goal made", 5, 2);
            _ratingPointService.AddRatingPoint(ppHandballGoalkeeper, RatingTypeEnum.Dynamic, "Goal received", -2, 3);
            _ratingPointService.AddRatingPoint(ppHandballGoalkeeper, RatingTypeEnum.Fixed, "Winner Score", 0, 4);


            var ppHandballFieldplayer = _playerPositionService.AddPlayerPosition(stHandball, "Field player (F)", "F");
            _ratingPointService.AddRatingPoint(ppHandballFieldplayer, RatingTypeEnum.Fixed, "Initial rating points", 20, 1);
            _ratingPointService.AddRatingPoint(ppHandballFieldplayer, RatingTypeEnum.Dynamic, "Goal made", 1, 2);
            _ratingPointService.AddRatingPoint(ppHandballFieldplayer, RatingTypeEnum.Dynamic, "Goal received", -1, 3);
            _ratingPointService.AddRatingPoint(ppHandballFieldplayer, RatingTypeEnum.Fixed, "Winner Score", 0, 4);



        }

        public void Run()
        {

            Console.WriteLine("Dosya Dizini Giriniz : ");
            var url = Console.ReadLine();
            _fileService.GetFiles(url);

            var players = _playerService.GetPlayers();
            foreach (var player in players)
            {
                Console.WriteLine(player.ToString());
            }

            var mvPlayers = _playerService.GetMVPlayers();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("MV Players");
            Console.WriteLine("-----------------------------------------");
            foreach (var player in mvPlayers)
            {
                Console.WriteLine(player.ToString());
                Console.WriteLine("-----------------------------------------");
            }

        }
    }
}
