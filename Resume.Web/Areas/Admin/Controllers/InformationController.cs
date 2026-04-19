using Microsoft.AspNetCore.Mvc;
using Resume.Application.Extensions;
using Resume.Application.Generator;
using Resume.Application.Services.Interfaces;
using Resume.Application.StaticTools;
using Resume.Domain.ViewModels.Information;

namespace Resume.Web.Areas.Admin.Controllers;

public class InformationController : AdminBaseController
{
    #region Information Service Constructor

    private readonly IInformationService _informationService;

    public InformationController(IInformationService informationService)
    {
        _informationService = informationService;
    }

    #endregion

    public async Task<IActionResult> LoadInformationFormModalAsync()
    {
        UpsertInformationViewModel model = await _informationService.FillUpsertInformationViewModelAsync();

        return PartialView("_InformationFormModalPartial", model);
    }

    public async Task<IActionResult> SubmitInformationFormModalAsync(UpsertInformationViewModel information)
    {
        var result = await _informationService.UpsertInformationAsync(information);

        if (result)
            return new JsonResult(new { status = "Success" });

        return new JsonResult(new { status = "Error" });
    }

    [HttpPost]
    public async Task<IActionResult> UploadInformationAvatarAjaxAsync(IFormFile file)
    {
        if (file != null)
        {
            if (Path.GetExtension(file.FileName) == ".png" ||
                Path.GetExtension(file.FileName) == ".jpeg" ||
                Path.GetExtension(file.FileName) == ".jpg")
            {
                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(file.FileName);
                await file.AddImageAjaxToServer(imageName, FilePaths.AvatarServer);
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

    [HttpPost]
    public async Task<IActionResult> UploadInformationResumeAjaxAsync(IFormFile file)
    {
        if (file != null)
        {
            if (Path.GetExtension(file.FileName) == ".pdf" ||
                Path.GetExtension(file.FileName) == ".docx")
            {
                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(file.FileName);
                await file.AddImageAjaxToServer(imageName, FilePaths.ResumeServer);
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