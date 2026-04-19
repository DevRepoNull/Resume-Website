using DNTCaptcha.Core;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Message;

namespace Resume.Web.Controllers;

public class ContactController : Controller
{
    #region Message Constructor

    private readonly IMessageService _messageService;

    private readonly IDNTCaptchaValidatorService _captchaValidator;

    private readonly IInformationService _informationService;

    public ContactController(IMessageService messageService, IDNTCaptchaValidatorService captchaValidator, IInformationService informationService)
    {
        _messageService = messageService;
        _captchaValidator = captchaValidator;
        _informationService = informationService;
    }

    #endregion
    
    public async Task<IActionResult> Index()
    {
        ViewData["Information"] = await _informationService.GetInformationDataAsync();
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(CreateMessageViewModel model)
    {
        ViewData["Information"] = await _informationService.GetInformationDataAsync();
        if (!_captchaValidator.HasRequestValidCaptchaEntry())
        {
            ViewData["FormSubmitResult"] = false;
            ModelState.AddModelError("DNTCaptchaText", "کد امنیتی اشتباه است.");
        }
        
        if (!ModelState.IsValid)
            return View(model);

        bool result = await _messageService.CreateMessageAsync(model);
        if (result)
        {
            ViewData["FormSubmitResult"] = true;
            return View();
        }

        return NotFound();
    }
}