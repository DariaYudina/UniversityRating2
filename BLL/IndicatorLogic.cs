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

        public List<Indicator> GetAllIndicatorsByUniversityAndIndicatorId(int universityId, int indicatorId)
        {
            return indicatorDao.GetAllIndicatorsByUniversityAndIndicatorId(universityId, indicatorId);
        }
    }
}
