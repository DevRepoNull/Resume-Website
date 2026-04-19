using Microsoft.AspNetCore.Mvc;
using Resume.Application.Extensions;
using Resume.Application.Generator;
using Resume.Application.Services.Interfaces;
using Resume.Application.StaticTools;
using Resume.Domain.ViewModels.CustomerLogo;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class CustomerLogoController : AdminBaseController
    {
        #region Customer Logo Constructor Service

        private readonly ICustomerLogoService _customerLogo;

        public CustomerLogoController(ICustomerLogoService customerLogo)
        {
            _customerLogo = customerLogo;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _customerLogo.GetCustomerLogoDataForIndexAsync());
        }

        public async Task<IActionResult> LoadCustomerLogoFormModalAsync(long id)
        {
            UpsertCustomerLogoViewModel result = await _customerLogo.FillCustomerLogoAsync(id);

            return PartialView("Partials/_CustomerLogoFormModal", result);
        }

        public async Task<IActionResult> SubmitCustomerLogoFormModalAsync(UpsertCustomerLogoViewModel customerLogo)
        {
            var result = await _customerLogo.UpsertCustomerLogoAsync(customerLogo);

            if (result)
                return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeleteCustomerLogoAsync(long id)
        {
            var result = await _customerLogo.DeleteCustomerLogoAsync(id);

            if (result)
                return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });

        }

        public async Task<IActionResult> UploadCustomerLogoImageAjaxAsync(IFormFile file)
        {
            if (file != null)
            {
                if (Path.GetExtension(file.FileName) == ".png" ||
                    Path.GetExtension(file.FileName) == ".jpeg" ||
                    Path.GetExtension(file.FileName) == ".jpg")
                {
                    var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(file.FileName);
                    await file.AddImageAjaxToServer(imageName, FilePaths.CustomerLogoServer);
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
