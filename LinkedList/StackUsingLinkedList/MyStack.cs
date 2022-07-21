using LinkedList;

namespace StackUsingLinkedList
{
  public class MyStack<T>
  {
    private readonly MyLinkedList<T> _stack = new MyLinkedList<T>();
    public void Push(T obj)
    {
      _stack.AddFirst(obj);
    }

    public T Pop()
    {
      if (_stack.MyLinkedListNode == null)
      {
        return default;
      }

      var obj = _stack.MyLinkedListNode.Value;
      _stack.MyLinkedListNode = _stack.MyLinkedListNode.NextNode;
      return obj;
    }

    public T Peek()
    {
       return _stack.MyLinkedListNode == null ? default : _stack.MyLinkedListNode.Value;
    }
    public int Count()
    {
      if (_stack.MyLinkedListNode == null)
      {
        return 0;
      }

      var currentNode = _stack.MyLinkedListNode;
      var count = 0;
      while (currentNode != null)
      {
        count++;
        currentNode = currentNode.NextNode;
        if (currentNode != null) continue;
        
        return count;
      }

      return 0;
    }

    public void PrintStack()
    {
      _stack.PrintList();
    }
  }
}
