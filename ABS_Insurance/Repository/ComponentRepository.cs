using System.ComponentModel;
using ABS_Insurance.Data.AppDBContext;
using ABS_Insurance.Interface;
using ABS_Insurance.Model;

namespace ABS_Insurance.Repository;

public class ComponentRepository : IComponentRepository
{
    private readonly AppDbContext _context;

    public ComponentRepository(AppDbContext context)
    {
        _context = context;
    }

    public ICollection<Components> GetComponents()
    {
        var components = _context.Components.OrderBy(c => c.ComponentsId).ToList();
        return components;
    }

    public Components GetComponent(int componentId)
    {
        var component = _context.Components.FirstOrDefault(c => c.ComponentsId == componentId);
        return component;
    }

    public bool ComponentExists(int componentId)
    {
        var component = _context.Components.Any(c => c.ComponentsId == componentId);
        return component;
    }

    public bool CreateComponent(Components component)
    {
        var newComponent = new Components()
        {
            Name = component.Name,
            Sequence = component.Sequence,
            Operation = component.Operation,
            FlatValue = component.FlatValue,
            PercentageValue = component.PercentageValue,
            Pol_Id = component.Pol_Id
        };
        _context.Components.Add(newComponent);
        return Save();
    }

    public bool UpdateComponent(Components component)
    {
        var components = _context.Components.Update(component);
        return Save();
    }

    public bool DeleteComponent(Components component)
    {
        var compnent = _context.Components.Remove(component);
        return Save();
    }
    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}