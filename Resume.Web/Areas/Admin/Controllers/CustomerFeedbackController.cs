using Microsoft.AspNetCore.Mvc;
using Resume.Application.Extensions;
using Resume.Application.Generator;
using Resume.Application.Services.Interfaces;
using Resume.Application.StaticTools;
using Resume.Domain.ViewModels.CustomerFeedback;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class CustomerFeedbackController : AdminBaseController
    {
        #region Customer Feedback Constructor

        private readonly ICustomerFeedBackService _customerFeedBack;

        public CustomerFeedbackController(ICustomerFeedBackService customerFeedBack)
        {
            _customerFeedBack = customerFeedBack;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _customerFeedBack.GetCustomerFeedBackForIndexAsync());
        }

        public async Task<IActionResult> LoadCustomerFeedbackFormModalAsync(long id)
        {
            UpsertCustomerFeedbackViewModel customer = await _customerFeedBack.FillUpsertCustomerFeedbackAsync(id);

            return PartialView("Partials/_CustomerFeedbackFormModal", customer);
        }

        public async Task<IActionResult> SubmitCustomerFeedbackFormModalAsync(UpsertCustomerFeedbackViewModel customerFeedback)
        {
            var result = await _customerFeedBack.UpsertCustomerFeedbackAsync(customerFeedback);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeleteCustomerFeedbackAsync(long id)
        {
            var result = await _customerFeedBack.DeleteCustomerFeedbackAsync(id);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> UploadCustomerFeedbackImageAjaxAsync(IFormFile file)
        {
            if (file != null)
            {
                if (Path.GetExtension(file.FileName) == ".png" ||
                    Path.GetExtension(file.FileName) == ".jpeg" ||
                    Path.GetExtension(file.FileName) == ".jpg")
                {
                    var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(file.FileName);
                    await file.AddImageAjaxToServer(imageName, FilePaths.CustomerFeedBackAvatarServer);
                    return new JsonResult(new { status = "Success", imageName = imageName });
                }
                else
                {
                    return new JsonResult(new { status = "Error" });
                }
            }
            else
            {
                return new JsonResult(new { status = "Error" });
            }
        }
    }
}
