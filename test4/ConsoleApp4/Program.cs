using System;
using System.Collections.Generic;

class Program
{
  // ฟังก์ชันที่ 1: แปลงจาก int → Roman Numerals
  public static string IntToRoman(int num)
  {
    var romanMap = new (int value, string symbol)[] {
            (1000, "M"),
            (900,  "CM"),
            (500,  "D"),
            (400,  "CD"),
            (100,  "C"),
            (90,   "XC"),
            (50,   "L"),
            (40,   "XL"),
            (10,   "X"),
            (9,    "IX"),
            (5,    "V"),
            (4,    "IV"),
            (1,    "I")
        };

    var result = "";
    foreach (var (value, symbol) in romanMap)
    {
      while (num >= value)
      {
        result += symbol;
        num -= value;
      }
    }
    return result;
  }

  // ฟังก์ชันที่ 2: แปลงจาก Roman Numerals → int
  public static int RomanToInt(string roman)
  {
    var map = new Dictionary<char, int> {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

    int total = 0;
    for (int i = 0; i < roman.Length; i++)
    {
      int value = map[roman[i]];

      if (i + 1 < roman.Length && map[roman[i + 1]] > value)
        total -= value;
      else
        total += value;
    }
    return total;
  }

  static void Main()
  {
    Console.WriteLine(IntToRoman(1989)); // MCMLXXXIX
    Console.WriteLine(IntToRoman(2000)); // MM
    Console.WriteLine(IntToRoman(68));   // LXVIII
    Console.WriteLine(IntToRoman(109));  // CIX

    Console.WriteLine(RomanToInt("MCMLXXXIX")); // 1989
    Console.WriteLine(RomanToInt("MM"));        // 2000
    Console.WriteLine(RomanToInt("LXVIII"));    // 68
    Console.WriteLine(RomanToInt("CIX"));       // 109
  }
}
