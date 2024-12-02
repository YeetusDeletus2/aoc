using NUnit.Framework;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace w1d2Tests;

[TestFixture]
public class Tests
{
    private bool CheckForSafe(List<int> list)
    {
        // Simulates the logic for checking safe reports
        int curr = list[0];
        int next = list[1];
        int count = 0;
        int notsafe = 0;
        int increasing = 0; // 0 unused, 1 inc, 2 dec
        foreach (int i in list)
        {
            count++;
            if (increasing == 0)
            {
                increasing = curr > next ? 2 : 1;
            }

            if (curr > next && increasing == 2)
            {
                // decreasing
                if (curr - 3 > next)
                {
                    // too much, unsafe
                    notsafe++;
                }
            }
            else if (curr < next && increasing == 1)
            {
                // increasing
                if (curr + 3 < next)
                {
                    // too much, unsafe
                    notsafe++;
                }
            }
            else
            {
                notsafe++;
            }

            try
            {
                curr = next;
                next = list[count + 1];
            }
            catch
            {
                // End of the list
                return notsafe <= 0;
            }
        }

        return false;
    }

    private List<List<int>> GenerateVariants(List<int> list)
    {
        // Generate all variants with one element removed
        var variants = new List<List<int>>();
        for (int i = 0; i < list.Count; i++)
        {
            var tempList = new List<int>(list);
            tempList.RemoveAt(i);
            variants.Add(tempList);
        }

        return variants;
    }

    [Test]
    public void TestSafeReportDecreasing()
    {
        var report = new List<int> { 7, 6, 4, 2, 1 };
        Assert.IsTrue(CheckForSafe(report));
    }

    [Test]
    public void TestUnsafeDueToLargeIncrease()
    {
        var report = new List<int> { 1, 2, 7, 8, 9 };
        Assert.IsFalse(CheckForSafe(report));
    }

    [Test]
    public void TestUnsafeDueToLargeDecrease()
    {
        var report = new List<int> { 9, 7, 6, 2, 1 };
        Assert.IsFalse(CheckForSafe(report));
    }

    [Test]
    public void TestMixedIncreasingDecreasing()
    {
        var report = new List<int> { 1, 3, 2, 4, 5 };
        Assert.IsFalse(CheckForSafe(report));
    }

    [Test]
    public void TestRepeatedValues()
    {
        var report = new List<int> { 8, 6, 4, 4, 1 };
        Assert.IsFalse(CheckForSafe(report));
    }

    [Test]
    public void TestSafeIncreasing()
    {
        var report = new List<int> { 1, 3, 6, 7, 9 };
        Assert.IsTrue(CheckForSafe(report));
    }

    [Test]
    public void TestToleratableByRemovingElement()
    {
        var report = new List<int> { 1, 3, 2, 4, 5 };
        var variants = GenerateVariants(report);
        bool isTolerable = false;
        foreach (var variant in variants)
        {
            if (CheckForSafe(variant))
            {
                isTolerable = true;
                break;
            }
        }

        Assert.IsTrue(isTolerable);
    }

    [Test]
    public void TestNotToleratable()
    {
        var report = new List<int> { 1, 2, 7, 8, 9 };
        var variants = GenerateVariants(report);
        bool isTolerable = false;
        foreach (var variant in variants)
        {
            if (CheckForSafe(variant))
            {
                isTolerable = true;
                break;
            }
        }

        Assert.IsFalse(isTolerable);
    }

    [Test]
    public void TestSafeWithDampener()
    {
        var report = new List<int> { 8, 6, 4, 4, 1 };
        var variants = GenerateVariants(report);
        bool isTolerable = false;
        foreach (var variant in variants)
        {
            if (CheckForSafe(variant))
            {
                isTolerable = true;
                break;
            }
        }

        Assert.IsTrue(isTolerable);
    }
}