using ABS_Insurance.Model;

namespace ABS_Insurance.Interface;

public interface IPremiumService
{ 
    double CalculatePremium(double marketValue, int policyId);
}