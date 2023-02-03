using ABS_Insurance.Data.AppDBContext;
using ABS_Insurance.Interface;
using ABS_Insurance.Model;

namespace ABS_Insurance.Repository;

public class PolicyRepository: IPolicy
{
    private readonly AppDbContext _context;

    public PolicyRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public ICollection<Policy> GetPolicies()
    {
        var policy = _context.Policies.OrderBy(p => p.PolicyId).ToList();
        return policy;
    }

    public Policy GetPolicy(int policyId)
    {
        var policy = _context.Policies.Where(p => p.PolicyId == policyId).FirstOrDefault();
        return policy;
    }

    public bool PolicyExists(int policyId)
    {
        var policy = _context.Policies.Any(p => p.PolicyId == policyId);
        return policy;
    }

    public bool CreatePolicy(Policy createPolicy)
    {
        var policy = _context.Policies.Add(createPolicy);
        return Save();
    }

    public bool UpdatePolicy(Policy updatepolicy)
    {
        var policy = _context.Policies.Update(updatepolicy);
        return Save();
    }

    public bool DeletePolicy(Policy deletePolicy)
    {
        var policy = _context.Policies.Remove(deletePolicy);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}