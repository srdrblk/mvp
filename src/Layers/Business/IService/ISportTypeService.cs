using Domain.Entities;
namespace Business.IService
{
    public interface ISportTypeService
    {
        SportType AddSportType(string sportName, string winParameter);
        List<SportType> GetSportTypes();
        SportType GetSportTypesByName(string name);
    }
}
