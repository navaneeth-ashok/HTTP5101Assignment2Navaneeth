using System.Web;
using System.Web.Mvc;

namespace HTTP5101Assignment2Navaneeth
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
