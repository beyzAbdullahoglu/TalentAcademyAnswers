using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;


public static string FilterPeopleFromXml(string xmlData)
{
	// XML verisini ayrýþtýr.
	var doc = XDocument.Parse(xmlData);

	//XML'den kiþileri oku ve filtrele.
	var people = doc.Descendants("Person")
		.Select(p => new
		{
			Name = (string)p.Element("Name"),
			Age = (int)p.Element("Age"),
			Department = (string)p.Element("Department"),
			Salary = (int)p.Element("Salary"),
			HireDate = DateTime.Parse((string)p.Element("HireDate"))
		})
		//Gereken filtreleri uygula.
		.Where(p => p.Age > 30
					&& p.Department == "IT"
					&& p.Salary > 5000
					&& p.HireDate.Year < 2019)
		.ToList();

	//Ýsimleri alfabetik sýrala.
	var names = people.Select(p => p.Name).OrderBy(n => n).ToList();

	//Maaþ ve sayým ile ilgili hesaplamalarý yap.
	var totalSalary = people.Sum(p => p.Salary);
	var averageSalary = people.Count > 0 ? people.Average(p => p.Salary) : 0;
	var maxSalary = people.Count > 0 ? people.Max(p => p.Salary) : 0;
	var count = people.Count;

	// Sonuçlarý JSON formatýnda döndür.
	var result = new
	{
		Names = names,
		TotalSalary = totalSalary,
		AverageSalary = averageSalary,
		MaxSalary = maxSalary,
		Count = count
	};

	//JSON string olarak döndür.
	return JsonSerializer.Serialize(result);
}

