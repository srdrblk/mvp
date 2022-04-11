using Domain.Entities;

namespace Business.IService
{
    public interface ITeamService
    {
        Team AddTeam(string name);
        List<Team> AddTeams(List<Team> teams);
        List<Team> GetTeams();
        Team GetTeamByName(string name);
    }
}
