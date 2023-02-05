using ABS_Insurance.Model;

namespace ABS_Insurance.Data.Dto;

public class PolicyDto
{
    public int PolicyId { get; set; }
    public string PolicyName { get; set; } = null!;
    //public ICollection<Components> ComponentsCollection { get; set; }
}