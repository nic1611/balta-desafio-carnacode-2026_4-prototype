
namespace DesignPatternChallenge.Templates;

public interface IPrototype
{
    IPrototype Clone();
    IPrototype DeepCopy();
}
    