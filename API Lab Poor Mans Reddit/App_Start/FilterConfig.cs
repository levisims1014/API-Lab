using System.Web;
using System.Web.Mvc;

namespace API_Lab_Poor_Mans_Reddit
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
