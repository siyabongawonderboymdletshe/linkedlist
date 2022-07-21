using System;
using System.Collections.Generic;
using LinkedListLibrary;

namespace LinkedList
{
  public class MyLinkedList<T>

  {
    public MyLinkedListNode<T> MyLinkedListNode { get; set; }

    public void AddFirst(T value)
    {
      if (MyLinkedListNode == null)
      {
        MyLinkedListNode = new MyLinkedListNode<T> {Value = value};
        return;
      }

      var newHeadNode = new MyLinkedListNode<T> {Value = value, NextNode = MyLinkedListNode};
      MyLinkedListNode = newHeadNode;
    }
    public void AddFirst(MyLinkedListNode<T> node)
    {
      if (MyLinkedListNode == null)
      {
        MyLinkedListNode = node;
        return;
      }

      var newHeadNode = node;
      newHeadNode.NextNode = MyLinkedListNode;
      MyLinkedListNode = newHeadNode;
    }
    public void AddLast(T value)
    {
      if (MyLinkedListNode == null)
      {
        MyLinkedListNode = new MyLinkedListNode<T> { Value = value };
        return;
      }

      if (MyLinkedListNode.NextNode == null)
      {
        var newNextNode = new MyLinkedListNode<T> { Value = value };
        MyLinkedListNode.NextNode = newNextNode;
        return;
      }

      var currentNode = MyLinkedListNode;
      var lastNode = currentNode.NextNode;

      while (currentNode != null)
      {
        lastNode = currentNode.NextNode ?? currentNode;
        currentNode = lastNode.NextNode;
      }
      lastNode.NextNode = new MyLinkedListNode<T> { Value = value };
    }
    public void AddLast(MyLinkedListNode<T> node)
    {
      if (MyLinkedListNode == null)
      {
        MyLinkedListNode = node;
        return;
      }

      if (MyLinkedListNode.NextNode == null)
      {
        if (Equals(MyLinkedListNode, node))
        {
          return;
        }
        MyLinkedListNode.NextNode = node;
        return;
      }

      var currentNode = MyLinkedListNode;
      var lastNode = currentNode.NextNode;

      while (currentNode != null)
      {
        if (Equals(currentNode, node))
        {
          break;
        }

        if (lastNode.NextNode == null)
        {
          lastNode.NextNode = node;
          break;
        }

        lastNode = lastNode.NextNode;
        currentNode = lastNode;
      }
    }
    public void AddBefore(MyLinkedListNode<T> node, T value)
    {
      if (!DoesNodeExists(node))
      {
        Console.WriteLine($"\nThe provided node does not exist in the list.");
        return;
      }

      if (MyLinkedListNode?.NextNode == null)
      {
        AddFirst(value);
        return;
      }

      var currentNode = MyLinkedListNode;
      var lastNode = currentNode.NextNode;
      var newNode = new MyLinkedListNode<T> { Value = value };

      if (currentNode == node)
      {
        newNode.NextNode = currentNode;
        MyLinkedListNode = newNode;
        return;
      }

      while (currentNode != null)
      {
        currentNode = lastNode;
        lastNode = lastNode.NextNode;

        if (currentNode != node) continue;
        AddBefore(currentNode, newNode);

        break;

      }
    }
    public void AddBefore(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
    {
      if (!DoesNodeExists(node))
      {
        Console.WriteLine($"\nThe provided node does not exist in the list.");
        return;
      }

      if (MyLinkedListNode == null)
      {
        MyLinkedListNode = newNode;
        return;
      }

      if (MyLinkedListNode.NextNode == null)
      {
        if (Equals(MyLinkedListNode, newNode))
        {
          return;
        }
        AddFirst(newNode);
        return;
      }

      var currentNode = MyLinkedListNode;
      var lastNode = currentNode.NextNode;

      if (currentNode == node)
      {
        if (DoesNodeExists(newNode)) return;

        AddFirst(newNode);
        return;
      }

      while (currentNode != null)
      {
        if (Equals(lastNode, currentNode))
        {
          break;
        }

        var previousNode = currentNode;
        currentNode = lastNode;
        lastNode = lastNode.NextNode;

        if (currentNode != node) continue;

        if (DoesNodeExists(newNode))
        {
          break;
        }
        previousNode.NextNode = newNode;
        newNode.NextNode = currentNode;
        break;
      }
    }
    public void AddAfter(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
    {
      if (!DoesNodeExists(node))
      {
        Console.WriteLine($"\nThe provided node does not exist in the list.");
        return;
      }

      if (MyLinkedListNode == null)
      {
        MyLinkedListNode = newNode;
        return;
      }

      if (MyLinkedListNode.NextNode == null)
      {
        if (Equals(MyLinkedListNode, newNode))
        {
          return;
        }

        MyLinkedListNode.NextNode = newNode;
        return;
      }

      var currentNode = MyLinkedListNode;
      var lastNode = currentNode.NextNode;

      if (currentNode == node)
      {
        if (DoesNodeExists(newNode)) return;

        currentNode.NextNode = newNode;
        newNode.NextNode = lastNode;
        return;
      }

      while (currentNode != null)
      {
        if (Equals(lastNode, currentNode))
        {
          return;
        }

        currentNode = lastNode;

        if (lastNode.NextNode != null)
        {
          lastNode = lastNode.NextNode;
        }

        if (lastNode == null)
        {
          currentNode.NextNode = newNode;
        }

        if (currentNode != node) continue;

        if (DoesNodeExists(newNode)) break;

        if (currentNode.NextNode != null)
        {
          newNode.NextNode = currentNode.NextNode;
          currentNode.NextNode = newNode;
          break;
        }

        currentNode.NextNode = newNode;
        break;
      }
    }
    public void AddAfter(MyLinkedListNode<T> node, T value)
    {
      if (!DoesNodeExists(node))
      {
        Console.WriteLine($"\nThe provided node does not exist in the list.");
        return;
      }

      if (MyLinkedListNode == null)
      {
        MyLinkedListNode = new MyLinkedListNode<T>() { Value = value};
        return;
      }

      if (MyLinkedListNode.NextNode == null)
      {
        MyLinkedListNode.NextNode = new MyLinkedListNode<T>() { Value = value };
        return;
      }

      var currentNode = MyLinkedListNode;
      var lastNode = currentNode.NextNode;
      var newNode = new MyLinkedListNode<T>() { Value = value };

      if (currentNode == node)
      {
        currentNode.NextNode = newNode;
        newNode.NextNode = lastNode;
        return;
      }

      while (currentNode != null)
      {
        if (Equals(lastNode, currentNode))
        {
          return;
        }

        currentNode = lastNode;

        if (lastNode.NextNode != null)
        {
          lastNode = lastNode.NextNode;
        }

        if (lastNode == null)
        {
          currentNode.NextNode = newNode;
        }

        if (currentNode != node) continue;

        if (DoesNodeExists(newNode)) break;

        if (currentNode.NextNode != null)
        {
          newNode.NextNode = currentNode.NextNode;
          currentNode.NextNode = newNode;
          break;
        }

        currentNode.NextNode = newNode;
        break;
      }
    }
    public void RemoveFirst()
    {
      if (MyLinkedListNode == null)
      {
        return;
      }

      if (MyLinkedListNode.NextNode == null)
      {
        MyLinkedListNode = null;
        return;
      }
      MyLinkedListNode = MyLinkedListNode.NextNode;
    }
    public void RemoveLast()
    {
      if (MyLinkedListNode == null)
      {
        return;
      }

      if (MyLinkedListNode.NextNode == null)
      {
        MyLinkedListNode = null;
        return;
      }

      var currentNode = MyLinkedListNode;
      while (currentNode != null)
      {
        var previousNode = currentNode;
        currentNode = currentNode.NextNode;
        if (currentNode?.NextNode != null) continue;

        previousNode.NextNode = null;
        currentNode = null;
      }
    }
    public void Clear()
    {
      MyLinkedListNode = null;
    }
    public void Remove(MyLinkedListNode<T> node)
    {
      if (MyLinkedListNode == null || !DoesNodeExists(node))
      {
        return;
      }

      var currentNode = MyLinkedListNode;

      if (currentNode.Equals(node))
      {
        MyLinkedListNode = MyLinkedListNode.NextNode;
        return;
      }

      while (currentNode != null)
      {
        var previousNode = currentNode;
        currentNode = currentNode.NextNode;

        if (!currentNode.Equals(node)) continue;

        previousNode.NextNode = currentNode.NextNode;
        break;
      }
    }
    public void Remove(T value)
    {
      if (MyLinkedListNode == null)
      {
        return;
      }

      var currentNode = MyLinkedListNode;

      if (currentNode.Value.Equals(value))
      {
        MyLinkedListNode = MyLinkedListNode.NextNode;
        return;
      }

      while (currentNode != null)
      {
        var previousNode = currentNode;
        currentNode = currentNode.NextNode;
        var currentNodeValue = currentNode.Value;

        if (!currentNodeValue.Equals(value)) continue;

        previousNode.NextNode = currentNode.NextNode;
        break;
      }
    }
    public bool Contains(T value)
    {
      if (MyLinkedListNode == null)
      {
        return false;
      }

      var currentNode = MyLinkedListNode;

      if (currentNode.Value.Equals(value))
      {
        return true;
      }

      while (currentNode != null)
      {
        if (currentNode.NextNode == null)
        {
          return false;
        }
        currentNode = currentNode.NextNode;
        var currentNodeValue = currentNode.Value;

        if (!currentNodeValue.Equals(value)) continue;

        return true;
      }

      return false;
    }

    public T GetNthFromLast(MyLinkedListNode<T> head, int k)
    {
      //Your code here
      if (head == null)
      {
        return default;
      }

      var size = 0;
      var tail = head;
      while (tail != null)
      {
        size++;
        tail = tail.NextNode;
      }

      var count = 0;
      while (head != null)
      {
        count++;
        if (count == (size - k) + 1)
        {
          return head.Value;
        }
        head = head.NextNode;
      }

      return default;
    }
    public T GetMiddleNode(MyLinkedListNode<T> head)
    {
      //Your code here
      if (head == null)
      {
        return default;
      }

      var size = 0;
      var tail = head;
      while (tail != null)
      {
        size++;
        tail = tail.NextNode;
      }

      var count = 0;
      var middle = size / 2 + 1;
      while (head != null)
      {
        count++;
        if (count == middle)
        {
          return head.Value;
        }
        head = head.NextNode;
      }

      return default;
    }

    public MyLinkedListNode<T> GetReverseList()
    {
      //Your code here
      if (MyLinkedListNode == null)
      {
        return default;
      }

      var list = new List<MyLinkedListNode<T>>();
      var head = MyLinkedListNode;
      while (head != null)
      {
        list.Add(head);
        head = head.NextNode;
      }


      var size = list.Count - 1;
      MyLinkedListNode = list[size];
      var tail = MyLinkedListNode;
      for (var i = size - 1; i>=0; i-- )
      {
        tail.NextNode = new MyLinkedListNode<T>() { Value = list[i].Value};
        tail = tail.NextNode;
      }


      return MyLinkedListNode;
    }

    public bool isPalindrome()
    {
      //Your code here
      if (MyLinkedListNode == null)
      {
        return default;
      }

      var list = new List<MyLinkedListNode<T>>();
      var head = MyLinkedListNode;
      while (head != null)
      {
        list.Add(head);
        head = head.NextNode;
      }


      var size = list.Count - 1;
      MyLinkedListNode = list[size];
      var tail = MyLinkedListNode;
      for (var i = size - 1; i >= 0; i--)
      {
        tail.NextNode = new MyLinkedListNode<T>() { Value = list[i].Value };
        tail = tail.NextNode;
      }


      return true;
    }

    public MyLinkedListNode<T> GetList()
    {
      return MyLinkedListNode;
    }
    public bool DoesNodeExists(MyLinkedListNode<T> node)
    {
      if (MyLinkedListNode == null)
      {
        return false;
      }

      var currentNode = MyLinkedListNode;

      if (currentNode.Equals(node))
      {
        return true;
      }

      while (currentNode != null)
      {
        currentNode = currentNode.NextNode;

        if (currentNode!= null && currentNode.Equals(node))
        {
          return true;
        }
      }

      return false;
    }

    public bool DetectAndRemoveLoop()
    {
      if (MyLinkedListNode?.NextNode == null)
      {
        return false;
      }

      var currentNode = MyLinkedListNode;
      var nextNode = currentNode.NextNode;

      if (currentNode == nextNode.NextNode)
      {
        nextNode.NextNode = null;
        return true;
      }

      var listOfNodes = new List<MyLinkedListNode<T>>
      {
        currentNode
      };

      while (nextNode != null)
      {
        listOfNodes.Add(nextNode);
        currentNode = nextNode;
        nextNode = nextNode.NextNode;

        if (!listOfNodes.Contains(nextNode)) continue;

        Console.WriteLine($"\nThe list contains the loop at Node {nextNode.Value} and it has been removed.\n");
        currentNode.NextNode = null;
        return true;

      }

      return false;
    }
    public void PrintList()
    {
      var currentNode = MyLinkedListNode;
      if (currentNode== null)
      {
        return;
      }

      if (currentNode.NextNode == null)
      {
        Console.WriteLine($"Node: {currentNode.Value}, NextNode: []");
        return;
      }

      if (DetectAndRemoveLoop())
      {
        Console.WriteLine($"\nThe list contains the loop and it has been removed.\n");
      }

      var value = currentNode.Value;
      var nextNode = currentNode.NextNode;
      if (value != null && nextNode == null)
      {
        Console.WriteLine($"Node: {currentNode.Value}, NextNode: []");
        return;
      }

      while (currentNode!= null)
      {
        if (currentNode.NextNode == null)
        {
          Console.WriteLine($"Node: {currentNode.Value}, NextNode: []");
          return;
        }

        nextNode = currentNode.NextNode;
        Console.WriteLine($"Node: {currentNode.Value}, NextNode: {nextNode.Value}");
        currentNode = currentNode.NextNode;
      }
    }
  }
}
