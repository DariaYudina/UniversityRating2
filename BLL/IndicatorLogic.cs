using System;
using System.Collections.Generic;
using Common;
using DAL;


namespace BLL
{
    public class IndicatorLogic : IIndicatorLogic
    {
        private readonly IIndicatorDao indicatorDao;

        public IndicatorLogic(IIndicatorDao indicatorDao)
        {
            this.indicatorDao = indicatorDao;
        }

        public bool CreateIndicatorForUniversity(Indicator indicator)
        {
            return indicatorDao.CreateIndicatorForUniversity(indicator);
        }

        public bool UpdateIndicatorForUniversity(Indicator indicator)
        {
            return indicatorDao.UpdateIndicatorForUniversity(indicator);
        }

        public bool CreateIndicator(Indicator indicator)
		{
            return indicatorDao.CreateIndicator(indicator);
        }
        public bool UpdateIndicator(Indicator indicator)
		{
            return indicatorDao.UpdateIndicator(indicator);
        }

        public List<Indicator> GetAllIndicators(int universityid)
        {
            return indicatorDao.GetAllIndicators(universityid);
        }

        public List<University> GetAllUniversities()
		{
            return indicatorDao.GetAllUniversities();
        }

        public List<int> GetAllYearsByUniversityId(int universityId)
        {
            return indicatorDao.GetAllYearsByUniversityId(universityId);
        }

		public List<Indicator> GetAllIndicatorsByUniversityAndYear(int universityId, int year)
		{
            return indicatorDao.GetAllIndicatorsByUniversityAndYear(universityId, year);
        }

        public List<Indicator> GetAllIndicatorsByUniversity(int universityId)
		{
            return indicatorDao.GetAllIndicatorsByUniversity(universityId);
        }

        public List<Indicator> GetIndicatorsByIdAndUniversity(int universityId, int indicatorId)
		{
            return indicatorDao.GetIndicatorsByIdAndUniversity(universityId, indicatorId);
        }
    }
}
