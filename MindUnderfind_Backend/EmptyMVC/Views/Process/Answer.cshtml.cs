using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Tracing;
using DataBaseModels;
using ModelTranslator.DAO;
using ModelTranslator.DTO;
using ModelTranslator;

namespace EmptyMVC.Views.Home
{
    public class AnswerModel : PageModel
    {
        public int VkId { get; set; } = -1;
        public Process ProcessType { get; set; } = Process.None;
        public int ComVkId { get; set; } = -1;
        public List<User> UsersArr { get; set; } = new();
        public List<Community> GroupsArr { get; set; } = new();
        public List<CommunityUsers> CommunityUser { get; set; } = new();

        public AnswerModel() { }
        public AnswerModel(int vkId, Process processType, int comVkId, List<User> usersArr,
                            List<Community> groupsArr, List<CommunityUsers> communityUsers)
        {
            VkId = vkId;
            ProcessType = processType;
            ComVkId = comVkId;
            UsersArr = usersArr;
            GroupsArr = groupsArr;
            CommunityUser = communityUsers;
        }
        public AnswerModel(ProcessDto dto, ResponseDao dao) : this(dto.VkId, dto.ProcessType, dto.ComVkId, dao.UserArr, dao.GroupArr, dao.CommunityUser) { }
    }
}
