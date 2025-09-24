using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
  public static List<string> Autocomplete(string search, List<string> items, int maxResult)
  {
    search = search.ToLower();

    var results = items
        .Where(item => item.ToLower().Contains(search)) // filter เอาเฉพาะที่มี search
        .OrderBy(item =>
        {
          string lower = item.ToLower();
          if (lower.StartsWith(search)) return 0;      // ต้นคำ
          else if (lower.EndsWith(search)) return 2;   // ท้ายคำ
          else return 1;                               // กลางคำ
        })
        .Take(maxResult) // จำกัดผลลัพธ์
        .ToList();

    return results;
  }

  public static void Main()
  {
    var items = new List<string> { "Mother", "Think", "Worthy", "Apple", "Android" };
    var result = Autocomplete("th", items, 2);

    Console.WriteLine("[" + string.Join(", ", result) + "]");
    // Output: [Think, Mother]
  }
}
