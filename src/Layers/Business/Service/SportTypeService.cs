using Business.IService;
using Domain.Entities;

namespace Business.Service
{
    public class SportTypeService :ISportTypeService 
    {
        public List<SportType> SportTypes { get; set; }
        public SportTypeService()
        {
            SportTypes = new List<SportType>();
        }
        public SportType AddSportType(string sportName,string winParameter)
        {
            var sportType = new SportType();
            if (!SportTypes.Any(s=>s.Name == sportName))
            {
                var id = !SportTypes.Any() ? 1 : SportTypes.LastOrDefault().Id + 1;
                sportType.Name = sportName;
                sportType.WinParameter = winParameter;
                sportType.Id = id;
                SportTypes.Add(sportType);
            }

            return sportType;
        }
        public List<SportType> GetSportTypes()
        {
            return SportTypes;
        }

        public SportType GetSportTypesByName(string name)
        {
            return SportTypes.SingleOrDefault(st => st.Name == name);
        }
    }
}
