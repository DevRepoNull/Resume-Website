using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBaseController : Controller
    {
        protected string SuccessMessage = "SuccessMessage";
        protected string WarningMessage = "WarningMessage";
        protected string InfoMessage = "InfoMessage";
        protected string ErrorMessage = "ErrorMessage";

        // Task : راهی مشترک پیدا کنیم بجای اینکه هربار عنوان جدول ها رو دستی بنویسیم از یک متن ثابت بخونیم
        #region General Title Table Name

        //protected const string Title = "عنوان";
        //protected const string Icon = "آیکون";
        //protected const string Description = "توضیحات";
        //protected const string Detail = "جزئیات";
        //protected const string Commands = "دستورات";

        #endregion
    }
}
