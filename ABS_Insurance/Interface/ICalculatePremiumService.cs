using ABS_Insurance.Model;

namespace ABS_Insurance.Interface;

public interface ICalculatePremuimService
{
    PremiumRes CalculatePremium(double marketValue, int policyId);
}