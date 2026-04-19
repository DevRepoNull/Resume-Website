using Resume.Domain.ViewModels.Education;
using Resume.Domain.ViewModels.Experience;
using Resume.Domain.ViewModels.Skill;

namespace Resume.Domain.ViewModels.Page;

public class ResumePageViewModel
{
    public List<EducationViewModel> EducationList { get; set; }

    public List<ExperienceViewModel> ExperienceList { get; set; }

    public List<SkillViewModel> SkillList { get; set; }
}