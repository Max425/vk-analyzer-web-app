namespace ModelTranslator.DAO;

public class RequestDao
{
    public int VkId { get; set; }
    public int ComVkId { get; set; }
    public Process ProcessType { get; set; }
    public RequestDao(int vkId, int comVkId = -1, Process process = Process.None)
    {
        VkId = vkId;
        ComVkId = comVkId;
        ProcessType = process;
    }
}