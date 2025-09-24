using System;
using System.Text.RegularExpressions;

class Program
{
  static void Main()
  {
    string[] arr1 = { "TH19", "SG20", "TH2" };
    string[] arr2 = { "TH10", "TH3Netflix", "TH1", "TH7" };

    Console.WriteLine(string.Join(", ", SortArray(arr1)));
    // Output: SG20, TH2, TH19

    Console.WriteLine(string.Join(", ", SortArray(arr2)));
    // Output: TH1, TH3Netflix, TH7, TH10
  }

  static string[] SortArray(string[] arr)
  {
    Array.Sort(arr, (a, b) =>
    {
      var regex = new Regex(@"^([A-Za-z]+)(\d+)(.*)$");

      var matchA = regex.Match(a);
      var matchB = regex.Match(b);

      string prefixA = matchA.Success ? matchA.Groups[1].Value : a;
      string prefixB = matchB.Success ? matchB.Groups[1].Value : b;

      if (prefixA != prefixB)
        return string.Compare(prefixA, prefixB, StringComparison.Ordinal);

      int numA = matchA.Success ? int.Parse(matchA.Groups[2].Value) : 0;
      int numB = matchB.Success ? int.Parse(matchB.Groups[2].Value) : 0;

      if (numA != numB)
        return numA.CompareTo(numB);

      string suffixA = matchA.Success ? matchA.Groups[3].Value : "";
      string suffixB = matchB.Success ? matchB.Groups[3].Value : "";

      return string.Compare(suffixA, suffixB, StringComparison.Ordinal);
    });

    return arr;
  }
}
