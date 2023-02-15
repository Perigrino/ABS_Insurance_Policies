namespace ABS_Insurance.Model;

public class PremiumRes
{
    public PremiumRes(bool isSuccessful = false, string message = "failed", double premium = 0)
    {
        IsSuccessful = isSuccessful;
        Premium = premium;
        Message = message;
        
    }

    public bool IsSuccessful { get; set; }
    public string Message { get; set; }
    public double Premium { get; set; }
    public string PolicyName { get; set; }
    
    
    
}