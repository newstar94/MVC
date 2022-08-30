using System.Web;
using System.Web.Mvc;

namespace S3_P1_T2104E_DuongVT
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
