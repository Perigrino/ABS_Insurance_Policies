using ABS_Insurance.Model;

namespace ABS_Insurance.Interface;

public interface IComponentRepository
{
    ICollection<Components> GetComponents();
    Components GetComponent(int componentId);
    bool ComponentExists(int componentId);
    bool CreateComponent(Components component);
    bool UpdateComponent(Components component);
    bool DeleteComponent(Components component );
    bool Save();
}