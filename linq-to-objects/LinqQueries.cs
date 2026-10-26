using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Linq.Objects;

namespace Linq;

public static class LinqQueries
{
    public static IEnumerable<string> Task1(char c, IEnumerable<string> stringList)
    {
        return stringList.Where(s => s.Length > 1 && s.First() == c && s.Last() == c);
    }

    public static IEnumerable<int> Task2(IEnumerable<string> stringList)
    {
        return stringList.Select(s => s.Length).OrderBy(len => len);
    }

    public static IEnumerable<string> Task3(IEnumerable<string> stringList)
    {
        return stringList.Select(s => $"{s.First()}{s.Last()}");
    }

    public static IEnumerable<string> Task4(int k, IEnumerable<string> stringList)
    {
        return stringList
            .Where(s => s.Length == k && char.IsDigit(s.Last()))
            .OrderBy(s => s);
    }

    public static IEnumerable<string> Task5(IEnumerable<int> integerList)
    {
        return integerList
            .Where(n => n % 2 != 0)
            .OrderBy(n => n)
            .Select(n => n.ToString(CultureInfo.InvariantCulture));
    }

    public static IEnumerable<string> Task6(IEnumerable<int> numbers, IEnumerable<string> stringList)
    {
        return numbers.Select(n =>
            stringList.FirstOrDefault(s => s.Length == n && char.IsDigit(s.First())) ?? "Not found");
    }

    public static IEnumerable<int> Task7(int k, IEnumerable<int> integerList)
    {
        return integerList
            .Where(x => x % 2 == 0)
            .Except(integerList.Skip(k))
            .Reverse();
    }

    public static IEnumerable<int> Task8(int k, int d, IEnumerable<int> integerList)
    {
        return integerList
            .TakeWhile(x => x <= d)
            .Union(integerList.Skip(k))
            .OrderByDescending(x => x);
    }

    public static IEnumerable<string> Task9(IEnumerable<string> stringList)
    {
        return stringList
            .GroupBy(s => s.First())
            .Select(g => new { CharCode = g.Key, TotalLength = g.Sum(s => s.Length) })
            .OrderByDescending(x => x.TotalLength)
            .ThenBy(x => x.CharCode)
            .Select(x => $"{x.TotalLength}-{x.CharCode}");
    }

    public static IEnumerable<string> Task10(IEnumerable<string> stringList)
    {
        return stringList
            .OrderBy(s => s)
            .GroupBy(s => s.Length)
            .Select(g => new string(g.Select(s => char.ToUpper(s.Last(), CultureInfo.InvariantCulture)).ToArray()))
            .OrderByDescending(s => s.Length);
    }

    public static IEnumerable<YearSchoolStat> Task11(IEnumerable<Entrant> nameList)
    {
        return nameList
            .GroupBy(e => e.Year)
            .Select(g => new YearSchoolStat
            {
                Year = g.Key,
                NumberOfSchools = g.Select(e => e.SchoolNumber).Distinct().Count(),
            })
            .OrderBy(stat => stat.NumberOfSchools)
            .ThenBy(stat => stat.Year);
    }

    public static IEnumerable<NumberPair> Task12(IEnumerable<int> integerList1, IEnumerable<int> integerList2)
    {
        return integerList1
            .Join(
                integerList2,
                x => Math.Abs(x % 10),
                y => Math.Abs(y % 10),
                (x, y) => new NumberPair { Item1 = x, Item2 = y })
            .OrderBy(p => p.Item1)
            .ThenBy(p => p.Item2);
    }

    public static IEnumerable<YearSchoolStat> Task13(IEnumerable<Entrant> nameList, IEnumerable<int> yearList)
    {
        return yearList
            .GroupJoin(
                nameList,
                year => year,
                entrant => entrant.Year,
                (year, entrants) => new YearSchoolStat
                {
                    Year = year,
                    NumberOfSchools = entrants.Select(e => e.SchoolNumber).Distinct().Count(),
                })
            .OrderBy(stat => stat.NumberOfSchools)
            .ThenBy(stat => stat.Year);
    }

    public static IEnumerable<MaxDiscountOwner> Task14(
        IEnumerable<Supplier> supplierList,
        IEnumerable<SupplierDiscount> supplierDiscountList)
    {
        return supplierDiscountList
            .GroupBy(d => d.ShopName)
            .Select(g => g.OrderByDescending(d => d.Discount).ThenBy(d => d.SupplierId).First())
            .Select(best => new MaxDiscountOwner
            {
                ShopName = best.ShopName,
                Owner = supplierList.First(s => s.Id == best.SupplierId),
                Discount = best.Discount,
            })
            .OrderBy(m => m.ShopName);
    }

    public static IEnumerable<CountryStat> Task15(IEnumerable<Good> goodList, IEnumerable<StorePrice> storePriceList)
    {
        return goodList
            .GroupBy(g => g.Country)
            .Select(group => new
            {
                CountryName = group.Key,
                StorePrices = group.Join(
                    storePriceList,
                    g => g.Id,
                    p => p.GoodId,
                    (g, p) => p),
            })
            .Select(x => new CountryStat
            {
                Country = x.CountryName,
                StoresNumber = x.StorePrices.Select(p => p.Shop).Distinct().Count(),
                MinPrice = x.StorePrices.Any() ? x.StorePrices.Min(p => p.Price) : 0,
            })
            .OrderBy(stat => stat.Country);
    }
}
