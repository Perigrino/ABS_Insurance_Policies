using ABS_Insurance.Model;

namespace ABS_Insurance.Interface;

public interface IPolicy
{
    ICollection<Policy> GetPolicies();
    Policy GetPolicy(int policyId);
    bool PolicyExists(int policyId);
    bool CreatePolicy(Policy policy);
    bool UpdatePolicy(Policy policy);
    bool DeletePolicy(Policy policy);
    bool Save();

}