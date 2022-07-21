using System;

namespace StackUsingLinkedList
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var myStack = new MyStack<object>();
      myStack.Push(10);
      myStack.Push("Siya Mdletshe");
      myStack.Push('A');
      Console.WriteLine($"Number of Items: {myStack.Count()}\n");
      Console.WriteLine($"{myStack.Peek()}");
      Console.WriteLine($"{myStack.Pop()}");
      Console.WriteLine($"{myStack.Pop()}\n");

      myStack.PrintStack();
    }
  }
}
