Duck newDuck;
string type = Console.ReadLine();
// at compile-time, the system does not know which implementation of Duck will be used
if (type == "a")
{
    newDuck = new Mallard();
}
else
{
    newDuck = new NoiseMakingDuckThatCantFly();
}
// since all of these methods are defined on the parent class they will be available in the child class
newDuck.Float();
newDuck.Display();
newDuck.PerformFly();
newDuck.PerformQuack();
public abstract class Duck
{
    public abstract void Display(); // Display method will always change in implementation amongst all child classes
    public void Float() // Swim method will never change amongst child classes, so we define it here in a wat that cannot be altered
    {
        Console.WriteLine("The duck floats on water.");
    }
    // === BEHAVIOURS === //
    // behaviours that may change and may be reused amongst different subclasses
    // at compile-time, the parent class does not know which implementation it will use
    // however, it DOSE know that it will have the methods defined on the interface available
    protected IFlyBehaviour _flyBehaviour;
    protected IQuackBehaviour _quackBehaviour;
    public void PerformFly()
    {
        // at compile-time, the parent class does not know that this method will do, but it does know that it can call it
        _flyBehaviour.Fly();
    }
    public void PerformQuack()
    {
        _quackBehaviour.Quack();
    }
}
public class Mallard : Duck
{
    public override void Display()
    {
        Console.WriteLine("A grey duck with a striking green colour in the head.");
    }
    public Mallard()
    {
        _flyBehaviour = new FlyWithWings();
        _quackBehaviour = new QuackLikeADuck();
    }
        
}
public class NoiseMakingDuckThatCantFly : Duck
{
    public override void Display()
    {
        Console.WriteLine("This duck for some reason does not have wings and only quacks.");
    }
    public NoiseMakingDuckThatCantFly()
    {
        _flyBehaviour = new FlyUnable();
        _quackBehaviour = new QuackLikeADuck();
    }
}
public interface IFlyBehaviour
{
    void Fly();
}
public class FlyWithWings : IFlyBehaviour
{
    public void Fly()
    {
        Console.WriteLine("The duck flaps its wings and flies around.");
    }
}
public class FlyUnable : IFlyBehaviour
{
    public void Fly()
    {
        Console.WriteLine("This duck cannot fly.");
    }
}
public interface IQuackBehaviour
{
    void Quack();
}
public class QuackLikeADuck : IQuackBehaviour
{
    public void Quack()
    {
        Console.WriteLine("The duck quacks the way most ducks do.");
    }
}