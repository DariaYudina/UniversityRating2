using Common;
using System.Collections.Generic;

namespace DAL
{
    public interface IIndicatorDao
    {
        List<Indicator> GetAllIndicators(int universitiid);
        bool CreateIndicatorForUniversity(Indicator indicator);
        bool UpdateIndicatorForUniversity(Indicator indicator);
        bool CreateIndicator(Indicator indicator);
        bool UpdateIndicator(Indicator indicator);
        List<University> GetAllUniversities();
		List<int> GetAllYearsByUniversityId(int universityId);
        List<Indicator> GetAllIndicatorsByUniversityAndYear(int universityId, int year);
        List<Indicator> GetAllIndicatorsByUniversity(int universityId);
        List<Indicator> GetIndicatorsByIdAndUniversity(int universityd, int indicatorId);
    }
}
