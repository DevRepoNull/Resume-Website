using Microsoft.Extensions.DependencyInjection;
using Resume.Application.Services.Implementations;
using Resume.Application.Services.Interfaces;

namespace Resume.Infra.Ioc;


/*
 * این قسمت که معروف به inversion of control می باشد
 * به ما کمک می کند تا ما به جای اینکه هر بار به صورت دستی بیاییم
 * در program.cs به صورت دستی تمامی dependency ها رو تزریق کنیم
 * در اینجا به صورت هوشمندانه میاییم یک متد static تعریف می کنیم و فقط با کمک
 * یک کلاس در کل پروژه همه رو dependency ها را مدیریت می کنیم
 */
public class DependencyContainers
{
    // We Use Collection Data's
    public static void RegisterService(IServiceCollection service)
    {
        // We say call response time
        service.AddScoped<IThingIDoService, ThingIDoService>();

        service.AddScoped<ICustomerFeedBackService, CustomerFeedBackService>();

        service.AddScoped<ICustomerLogoService, CustomerLogoService>();

        service.AddScoped<IEducationService, EducationService>();

        service.AddScoped<IExperienceService, ExperienceService>();

        service.AddScoped<ISkillService, SkillService>();

        service.AddScoped<IPortfolioService, PortfolioService>();

        service.AddScoped<ISocialMediaService, SocialMediaService>();
        
        service.AddScoped<IInformationService, InformationService>();

        service.AddScoped<IMessageService, MessageService>();
    }
}