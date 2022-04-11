using Business.IService;
using Domain.Entities;

namespace Business.Service
{
    public class TeamService : ITeamService
    {
        private List<Team> Teams { get; set; }
        public TeamService()
        {
            Teams = new List<Team>();
        }
        public Team AddTeam(string name)
        {
            var team = Teams.SingleOrDefault(t => t.Name == name);
            if (team ==null)
            {
                team = new Team();
                team.Name = name;
                var id = !Teams.Any() ? 1 : Teams.LastOrDefault().Id + 1;
                team.Id = id;
                Teams.Add(team);
            }
    
            return team;

        }
        public List<Team> AddTeams(List<Team> teams)
        {
            var result = new List<Team>();
            foreach (Team team in teams)
            {
                result.Add(AddTeam(team.Name));
            }
            return result;

        }
        public List<Team> GetTeams() { return Teams; }
        public Team GetTeamByName(string name) { return Teams.SingleOrDefault(t=>t.Name==name); }
    }
}
