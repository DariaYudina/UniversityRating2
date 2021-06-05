using Common;
using System.Collections.Generic;

namespace DAL
{
    public interface IIndicatorDao
    {
        List<Indicator> GetAllIndicators(int universitiid);
        bool UpdateIndicator(Indicator indicator);
		List<University> GetAllUniversities();
		List<int> GetAllYearsByUniversityId(int universityId);
        List<Indicator> GetAllIndicatorsByUniversityAndYear(int universityId, int year);
    }
}
