using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class MessageController : AdminBaseController
    {
        #region Message Service Constructor

        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _messageService.GetMessageDataAsync());
        }

        public async Task<IActionResult> DeleteMessageAsync(long id)
        {
            bool result = await _messageService.DeleteMessageAsync(id);

            if (result)
                return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }
    }
}
