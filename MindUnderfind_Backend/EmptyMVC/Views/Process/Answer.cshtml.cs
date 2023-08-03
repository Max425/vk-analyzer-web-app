using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Tracing;
using DataBaseModels;
using ModelTranslator.DAO;
using ModelTranslator;
using ModelTranslator.DTO;
using ModelTranslator;

namespace EmptyMVC.Views.Home
{
    public class AnswerModel : PageModel
    {
        public int VkId { get; set; } = -1;
        public Process ProcessType { get; set; } = Process.None;
        public int ComVkId { get; set; } = -1;
        public List<UserDao> UsersArr { get; set; } = new();
        public List<CommunityDao> GroupsArr { get; set; } = new();
        public List<CommunityUserDao> CommunityUser { get; set; } = new();
        public int ErCode { get; set; } = 200;

        public AnswerModel() { }
        public AnswerModel(int vkId, Process processType, int comVkId, List<User> usersArr,
                            List<Community> groupsArr, List<CommunityUsers> communityUsers)
        {
            VkId = vkId;
            ProcessType = processType;
            ComVkId = comVkId;
            UsersArr = usersArr.ConvertAll((user) => ConverterMU.ToUserDao(user));
            GroupsArr = groupsArr.ConvertAll((group) => ConverterMU.ToCommunityDao(group));
            CommunityUser = communityUsers.ConvertAll((cm) => ConverterMU.ToComUserDao(cm));
        }
        public AnswerModel(RequestDto dto, ResponseDao dao) : this(dto.VkId, dto.ProcessType, dto.ComVkId, dao.UserArr, dao.GroupArr, dao.CommunityUser) { }
    }
}
