using System;
using System.Collections.Generic;

class Program
{
  static List<int> Tribonacci(List<int> start, int n)
  {
    // ถ้า n = 0 ให้ return list ว่าง
    if (n == 0) return new List<int>();

    // เอาเฉพาะ n ตัวแรกจาก start (กันกรณี start มีเยอะเกิน)
    List<int> result = new List<int>(start);
    if (result.Count > n)
      result = result.GetRange(0, n);

    // เติมค่าจนกว่าจะครบ n ตัว
    while (result.Count < n)
    {
      int nextVal;
      if (result.Count < 3)
      {
        // ถ้ายังไม่ถึง 3 ตัวให้บวกทั้งหมดที่มี
        nextVal = 0;
        foreach (int val in result)
          nextVal += val;
      }
      else
      {
        // กรณีปกติ ใช้ 3 ตัวท้ายมาบวก
        int len = result.Count;
        nextVal = result[len - 1] + result[len - 2] + result[len - 3];
      }

      result.Add(nextVal);
    }

    return result;
  }

  static void Main()
  {
    Console.WriteLine(string.Join(", ", Tribonacci([1, 3, 5], 5)));
    // Output: 1, 3, 5, 9, 17

    Console.WriteLine(string.Join(", ", Tribonacci([2, 2, 2], 3)));
    // Output: 2, 2, 2

    Console.WriteLine(string.Join(", ", Tribonacci([10, 10, 10], 4)));
    // Output: 10, 10, 10, 30

    // Console.WriteLine(string.Join(", ", Tribonacci([], 5)));
    // Output: 0, 0, 0, 0, 0

    // Console.WriteLine(string.Join(", ", Tribonacci([5, 2], 6)));
    // Output: 5, 2, 7, 14, 23, 44
  }
}
