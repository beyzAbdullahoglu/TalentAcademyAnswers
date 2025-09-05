using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;


public static string FilterPeopleFromXml(string xmlData)
{
	// XML verisini ayr��t�r.
	var doc = XDocument.Parse(xmlData);

	//XML'den ki�ileri oku ve filtrele.
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

	//�simleri alfabetik s�rala.
	var names = people.Select(p => p.Name).OrderBy(n => n).ToList();

	//Maa� ve say�m ile ilgili hesaplamalar� yap.
	var totalSalary = people.Sum(p => p.Salary);
	var averageSalary = people.Count > 0 ? people.Average(p => p.Salary) : 0;
	var maxSalary = people.Count > 0 ? people.Max(p => p.Salary) : 0;
	var count = people.Count;

	// Sonu�lar� JSON format�nda d�nd�r.
	var result = new
	{
		Names = names,
		TotalSalary = totalSalary,
		AverageSalary = averageSalary,
		MaxSalary = maxSalary,
		Count = count
	};

	//JSON string olarak d�nd�r.
	return JsonSerializer.Serialize(result);
}

