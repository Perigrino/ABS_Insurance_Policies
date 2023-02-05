using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ABS_Insurance.Model;

public class Policy
{ 
    public int PolicyId { get; set; }
    public string PolicyName { get; set; }
    //Navigation Properties
    public ICollection<Components>? ComponentsCollection { get; set; } = new List<Components>();
}