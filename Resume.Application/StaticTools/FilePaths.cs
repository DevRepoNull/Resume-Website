namespace Resume.Application.StaticTools;

public static class FilePaths
{
    // Base image url path
    private static readonly string BaseImagePath = "/content/images";
    private static readonly string BaseImagePathServer = $"wwwroot{BaseImagePath}";

    // Default image path
    public static readonly string DefaultAvatar = $"{BaseImagePath}/default/default-avatar.png";

    // Customer feedback avatar
    public static readonly string CustomerFeedBackAvatar = $"{BaseImagePath}/customer-feedback-avatar/origin/";

    public static readonly string CustomerFeedBackAvatarServer = Path.Combine(Directory.GetCurrentDirectory(),
        $"{BaseImagePathServer}/customer-feedback-avatar/origin/");

    // Customer Logo
    public static readonly string CustomerLogo = $"{BaseImagePath}/customer-logo/origin/";

    public static readonly string CustomerLogoServer = Path.Combine(Directory.GetCurrentDirectory(),
        $"{BaseImagePathServer}/customer-logo/origin/");
    
    // Portfolio
    public static readonly string Portfolio = $"{BaseImagePath}/portfolio/origin/";
    public static readonly string PortfolioServer = Path.Combine(Directory.GetCurrentDirectory(),
        $"{BaseImagePathServer}/portfolio/origin/");
    
    // Sidebar Avatar
    public static readonly string Avatar = $"{BaseImagePath}/avatar/origin/";
    public static readonly string AvatarServer = Path.Combine(Directory.GetCurrentDirectory(),
        $"{BaseImagePathServer}/avatar/origin/");
    
    // Resume File
    public static readonly string Resume = $"{BaseImagePath}/Resume/";
    public static readonly string ResumeServer = Path.Combine(Directory.GetCurrentDirectory(),
        $"{BaseImagePathServer}/Resume/");
}