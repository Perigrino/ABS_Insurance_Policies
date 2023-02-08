using System.ComponentModel.DataAnnotations.Schema;

namespace ABS_Insurance.Model;

public class Components
{
    public int ComponentsId { get; set; }
    public int Sequence { get; set; }
    public string Name { get; set; }
    public string Operation { get; set; }
    public double FlatValue { get; set; }
    public int PercentageValue { get; set; }
    public int Pol_Id { get; set; }
    public Policy Policy { get; set; }

}