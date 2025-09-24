using System;
using System.Linq;

class Program
{
  static int SortDigitsDesc(int number)
  {
    // แปลงเป็น string → array ของตัวอักษร → เรียงลำดับมากไปน้อย
    string sorted = new string(number
        .ToString()
        .OrderByDescending(c => c)  // ใช้ LINQ เรียงตัวเลขมากไปน้อย
        .ToArray());

    return int.Parse(sorted);
  }

  static void Main()
  {
    Console.WriteLine(SortDigitsDesc(3008)); // 8300
    Console.WriteLine(SortDigitsDesc(1989)); // 9981
    Console.WriteLine(SortDigitsDesc(2679)); // 9762
    Console.WriteLine(SortDigitsDesc(9163)); // 9631
  }
}
