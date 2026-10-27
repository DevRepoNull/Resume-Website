using Resume.Application.ViewModels.Education;
using Resume.Application.ViewModels.Experience;
using Resume.Application.ViewModels.Skill;

namespace Resume.Application.ViewModels.Page;

public class ResumePageViewModel
{
    public List<EducationViewModel> EducationList { get; set; }

    public List<ExperienceViewModel> ExperienceList { get; set; }

    public List<SkillViewModel> SkillList { get; set; }
}