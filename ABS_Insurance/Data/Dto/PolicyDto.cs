using ABS_Insurance.Model;

namespace ABS_Insurance.Data.Dto;

public class CreatePolicyDto
{
    public string PolicyName { get; set; } = null!;
    //public ICollection<Components> ComponentsCollection { get; set; }
}


public class UpdatePolicyDto
{
    public int PolicyId { get; set; }
    public string PolicyName { get; set; } = null!;
    //public ICollection<Components> ComponentsCollection { get; set; }
}