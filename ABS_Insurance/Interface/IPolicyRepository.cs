using ABS_Insurance.Model;

namespace ABS_Insurance.Interface;

public interface IPolicyRepository
{
    ICollection<Policy> GetPolicies();
    Policy GetPolicy(int policyId);
    bool PolicyExists(int policyId);
    bool CreatePolicy(Policy policy);
    bool UpdatePolicy(Policy policy);
    bool DeletePolicy(Policy policy);
    double CalculatePremium(double marketValue, int policyId);
    bool Save();

}