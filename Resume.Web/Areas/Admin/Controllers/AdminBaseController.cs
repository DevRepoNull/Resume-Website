using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [AutoValidateAntiforgeryToken]
    public class AdminBaseController : Controller
    {
        protected string SuccessMessage = "SuccessMessage";
        protected string WarningMessage = "WarningMessage";
        protected string InfoMessage = "InfoMessage";
        protected string ErrorMessage = "ErrorMessage";

        #region General Title Table Name

        //protected const string Title = "عنوان";
        //protected const string Icon = "آیکون";
        //protected const string Description = "توضیحات";
        //protected const string Detail = "جزئیات";
        //protected const string Commands = "دستورات";

        #endregion
    }
}
