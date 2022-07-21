using System;
using System.Collections.Generic;
using System.Linq;
using LinkedListLibrary;

namespace LinkedList
{
  public class Program
  {
    private static readonly MyLinkedList<object> MyList = new MyLinkedList<object>();
    private static string _method = "";
    private static List<MyLinkedListNode<object>> _values = new List<MyLinkedListNode<object>>();
    private const int DefaultListCount = 5;
    private const int MethodsCount = 5;
    private static void InvokeMethod(int methodId)
    {
      switch (methodId)
      {
        case 1:
          _method = "AddFirst()";
          AddRandomValues(DefaultListCount);
          Console.WriteLine("Enter the value....");
          var obj = Console.ReadLine();
          Console.WriteLine("\nThe LinkedList before invoking AddFirst():");
          MyList.PrintList();
          MyList.AddFirst(obj);
          Console.WriteLine("\nThe LinkedList after invoking AddFirst():");
          MyList.PrintList();
          break;
        case 2:
          _method = "AddLast()";
          AddRandomValues(DefaultListCount);
          Console.WriteLine("Enter the value....");
          obj = Console.ReadLine();
          Console.WriteLine("\nThe LinkedList before invoking AddLast():");
          MyList.PrintList();
          MyList.AddLast(obj);
          Console.WriteLine("\nThe LinkedList after invoking AddLast():");
          MyList.PrintList();
          break;
        case 3:
          _method = "AddBefore()";
          AddRandomValues(DefaultListCount);
          Console.WriteLine("\nThe LinkedList before invoking AddBefore():");
          MyList.PrintList();
          Console.WriteLine("\nPlease choose the value from the list....");
          var obj1 = Console.ReadLine();
          var node = GetNode(obj1);
          Console.WriteLine("Enter the new value....");
          var obj2 = new MyLinkedListNode<object>() {Value = Console.ReadLine()};
          Console.WriteLine("\nThe LinkedList before invoking AddBefore():");
          MyList.PrintList();
          MyList.AddBefore(node, obj2);
          Console.WriteLine("\nThe LinkedList after invoking AddBefore():");
          MyList.PrintList();
          break;
        case 4:
          _method = "AddAfter()";
          AddRandomValues(DefaultListCount);
          Console.WriteLine("\nThe LinkedList before invoking AddAfter():");
          MyList.PrintList();
          Console.WriteLine("\nPlease choose the value from the list....");
          obj1 = Console.ReadLine();
           node = GetNode(obj1);
          Console.WriteLine("Enter the new value....");
          obj2 = new MyLinkedListNode<object>() { Value = Console.ReadLine() };
          Console.WriteLine("\nThe LinkedList before invoking AddAfter():");
          MyList.PrintList();
          MyList.AddAfter(node, obj2);
          Console.WriteLine("\nThe LinkedList after invoking AddAfter():");
          MyList.PrintList();
          break;
        case 5:
          _method = "DetectAndRemoveLoop()";
          AddRandomValues(DefaultListCount);
          Console.WriteLine("\nThe LinkedList before invoking DetectAndRemoveLoop():");
          MyList.PrintList();
          Console.WriteLine("\nPlease choose the value from the list to create a loop....");
          obj1 = Console.ReadLine();
          node = GetNode(obj1);
          Console.WriteLine("\nThe LinkedList before invoking DetectAndRemoveLoop():");
          MyList.PrintList();
          _values[DefaultListCount - 1].NextNode = node;
          MyList.DetectAndRemoveLoop();
          Console.WriteLine("\nThe LinkedList after invoking DetectAndRemoveLoop():");
          MyList.PrintList();  
          break;
        default:
          MyList.PrintList(); break;
      }

    }

    private static void AddRandomValues(int count)
    {
      var rnd = new Random();

      for (var i = 0; i < count; i++)
      {
        var node = new MyLinkedListNode<object>()
        {
          Value = rnd.Next(1, 100)
        };
        _values.Add(node);
        MyList.AddLast(node);
      }
    }

    private static MyLinkedListNode<object> GetNode(object obj)
    {
      return _values?.FirstOrDefault(value => value.Value.ToString().Equals(obj.ToString()));
    }

    private static void RunProgram()
    {
      Console.WriteLine("In computer science, a linked list is a linear collection of data elements whose order is not given by their physical placement in memory. \nInstead, each element points to the next.\n");
      var method = -1;
      while (method == -1)
      {
        try
        {
          MyList.Clear();
          _values.Clear();
          Console.WriteLine("The LinkedList has the following methods:\n" +
                            "AddFirst() -> adds an element to the first position. \n" +
                            "AddLast() -> adds an element to the last position. \n" +
                            "AddBefore()-> adds an element before another. \n" +
                            "AddAfter() -> adds an element after another.\n" +
                            "DetectAndRemoveLoop() -> checks whether a given Linked List contains a loop and if the loop is present then removes the loop and returns true.");

          Console.WriteLine();

          Console.WriteLine("Please enter the number for the method you would like to call:\n" +
                            "AddFirst() -> 1\n" +
                            "AddLast() -> 2\n" +
                            "AddBefore() -> 3\n" +
                            "AddAfter() -> 4\n" +
                            "DetectAndRemoveLoop() -> 5");

          method = Convert.ToInt32(Console.ReadLine());

          if (method < 1 || method > MethodsCount)
          {
            Console.WriteLine("\nDo you want to make another method call? \nEnter 1 - for YES \nEnter 2 - for NO.");
            var exit = Convert.ToInt32(Console.ReadLine());
            method = exit != 1 ? 0 : -1;
            Console.Clear();
          }
          else
          {
            InvokeMethod(method);
            Console.WriteLine($"\nFinished Invoking {_method}.....................................\n");
            Console.WriteLine("Do you want to make another method call? \nEnter 1 - for YES \nEnter 2 - for NO.");
            var exit = Convert.ToInt32(Console.ReadLine());
            method = exit != 1 ? 0 : -1;
            Console.Clear();
          }
          
        }
        catch (Exception)
        {
          Console.WriteLine("Do you want to make another method call? \nEnter 1 - FOR YES \nEnter 2 - FOR NO.");
          var exit = Convert.ToInt32(Console.ReadLine());
          method = exit != 1 ? 0 : -1;
        }

      }
    }

    public static void Main(string[] args)
    {
      RunProgram();
    }
  }
}
