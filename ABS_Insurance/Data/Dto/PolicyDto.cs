using System.ComponentModel.DataAnnotations;
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


public class CalPremiumDto
{
    [Required]
    public int PolicyId { get; set; }
    [Range(0.1, 100)]
    public double MarketValue { get; set; }
    //public ICollection<Components> ComponentsCollection { get; set; }
}