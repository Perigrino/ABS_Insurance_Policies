namespace ABS_Insurance.Data.Dto;

public class ComponentDto
{
    public int ComponentsId { get; set; }
    public int Sequence { get; set; }
    public string Name { get; set; }
    public string Operation { get; set; }
    public double FlatValue { get; set; }
    public int PercentageValue { get; set; }
}


public class CreateComponentDto
{
    public int ComponentsId { get; set; }
    public int Sequence { get; set; }
    public string Name { get; set; }
    public string Operation { get; set; }
    public double FlatValue { get; set; }
    public int PercentageValue { get; set; }
    public int Pol_Id { get; set; }
}