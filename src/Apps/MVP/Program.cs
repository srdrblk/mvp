// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Business.IService;
using Business.Service;


var serviceProvider = new ServiceCollection()
          .AddSingleton<IFileService, FileService>()
          .AddSingleton<IMainService, MainService>()
          .AddSingleton<IPlayerPositionService, PlayerPositionService>()
          .AddSingleton<IPlayerService, PlayerService>()
          .AddSingleton<IRatingPointService, RatingPointService>()
          .AddSingleton<ISportTypeService,SportTypeService>()
          .AddSingleton<ITeamService, TeamService>()
        .BuildServiceProvider();


var bar = serviceProvider.GetService<IMainService>();
bar.Run();

