using ModelTranslator.DAO;

namespace ModelTranslator.DTO;

public class RequestDto
{
    public int VkId { get; set; } = -1;
    public Process ProcessType { get; set; } = Process.None;
    public int ComVkId { get; set; } = -1;

    public RequestDao ToRequestDao()
    {
        return new RequestDao(VkId, ComVkId, ProcessType);
    }
}