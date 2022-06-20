using System.Web;
using System.Web.Mvc;

namespace FamilyExpensesCourseWork
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
