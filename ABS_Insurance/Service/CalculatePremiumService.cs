using ABS_Insurance.Interface;
using ABS_Insurance.Model;
using ABS_Insurance.Repository;

namespace ABS_Insurance.Service;

public class CalculatePremiumService : ICalculatePremuimService
{
    private readonly IPolicyRepository _policyRepository;
    
    public CalculatePremiumService(IPolicyRepository policyRepository)
    {
        _policyRepository = policyRepository;
    }
    public PremiumRes CalculatePremium(double marketValue, int policyId)
    {
        var premiumRes = new PremiumRes();
        var policy = _policyRepository.GetPolicy(policyId);
        
        if (policy.ComponentsList == null) 
            return premiumRes;
        
        foreach (var p in policy.ComponentsList)
        {
            if (p.Operation == "add")
            {
                premiumRes.Premium += ((marketValue * p.PercentageValue/100) + p.FlatValue);
            }
            else
            {
                premiumRes.Premium -= ((marketValue * p.PercentageValue/100) - p.FlatValue);
            }
        }

        premiumRes.IsSuccessful = true;
        premiumRes.Message = "success";
        premiumRes.PolicyName = policy?.PolicyName;
        return premiumRes;  
    }
}