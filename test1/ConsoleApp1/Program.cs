using System;
using System.Collections.Generic;

class Program
{
  static bool IsValid(string s)
  {
    Stack<char> stack = new Stack<char>();
    Dictionary<char, char> pairs = new Dictionary<char, char>()
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

    foreach (char c in s)
    {
      if (c == '(' || c == '[' || c == '{')
      {
        stack.Push(c);
      }
      else if (c == ')' || c == ']' || c == '}')
      {
        if (stack.Count == 0 || stack.Peek() != pairs[c])
          return false;
        stack.Pop();
      }
    }

    return stack.Count == 0;
  }

  static void Main()
  {
    string[] tests = { "()", "([])", "({[]})", "([{]])", ")", "(})", "([)", "{" };
    foreach (var t in tests)
    {
      Console.WriteLine($"{t} => {IsValid(t)}");
    }
  }
}
