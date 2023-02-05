using ABS_Insurance.Data.AppDBContext;
using ABS_Insurance.Interface;
using ABS_Insurance.Model;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        var components = _context.Components.Where(c => c.ComponentsId == componentId).FirstOrDefault();
        return components;
    }

    public bool ComponentExists(int componentId)
    {
        var component = _context.Components.Any(c => c.ComponentsId == componentId);
        return component;
    }

    public bool CreateComponent(Components component)
    {
        var components = _context.Components.Add(component);
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