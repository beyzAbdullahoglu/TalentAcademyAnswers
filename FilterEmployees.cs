using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;


public static string FilterEmployees(IEnumerable<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)
{
    // Filtrelemek i�in gerekli kriterleri ayarla.
    var filtered = employees
        .Where(e => e.Age >= 25 && e.Age <= 40)
        .Where(e => e.Department == "IT" || e.Department == "Finance")
        .Where(e => e.Salary >= 5000m && e.Salary <= 9000m)
        .Where(e => e.HireDate.Year > 2017)
        .ToList();

    // Filtrelenmi� �al��anlar�n isimlerini al ve s�ralama yap.
    var sortedNames = filtered
        .Select(e => e.Name)
        .OrderByDescending(name => name.Length)
        .ThenBy(name => name)
        .ToList();

    // Maa� ile ilgili hesaplamalar� yap.
    decimal totalSalary = filtered.Sum(e => e.Salary);
    decimal averageSalary = filtered.Count > 0 ? filtered.Average(e => e.Salary) : 0m;
    decimal minSalary = filtered.Count > 0 ? filtered.Min(e => e.Salary) : 0m;
    decimal maxSalary = filtered.Count > 0 ? filtered.Max(e => e.Salary) : 0m;
    int count = filtered.Count;

    // Sonu�lar� JSON format�nda d�nd�r.
    var result = new
    {
        Names = sortedNames,
        TotalSalary = totalSalary,
        AverageSalary = Math.Round(averageSalary, 2),
        MinSalary = minSalary,
        MaxSalary = maxSalary,
        Count = count
    };

    //JSON string olarak d�nd�r.
    return JsonSerializer.Serialize(result);
}

