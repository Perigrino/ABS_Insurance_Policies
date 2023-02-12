using ABS_Insurance.Data.AppDBContext;
using ABS_Insurance.Interface;
using ABS_Insurance.Model;
using ABS_Insurance.Repository;
using Microsoft.EntityFrameworkCore;

namespace ABS_Insurance.Service;

public class PremuimService : IPremiumService
{
    private readonly PolicyRepository _policyRepository;
    public PremuimService(PolicyRepository policyRepository)
    {
        _policyRepository = policyRepository;
    }

    public double CalculatePremium(double marketValue, int policyId)
    {
        var policy = _policyRepository.GetPolicy(policyId);
        double perimuimValue = 0;
        foreach (var p in policy.ComponentsList)
        {
            if (p.Operation == "add")
            {
                perimuimValue += ((marketValue * p.PercentageValue) + p.FlatValue);
            }
            else
            {
                perimuimValue -= ((marketValue * p.PercentageValue) + p.FlatValue);
            }
        }
        return perimuimValue;
    }


}