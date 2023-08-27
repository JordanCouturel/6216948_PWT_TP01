using tp2JordanCoutureLafranchise.Models;
using tp2JordanCoutureLafranchise.Models.Data;

namespace tp3JordanCoutureLafranchise.Services
{
    public class ParentService:ServiceBaseAsync<Parent>,IParentService
    {
        public ParentService(HockeyRebelsDBContext dbContext) : base(dbContext) { }
    }
}
