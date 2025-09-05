
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;


public static string MaxIncreasingSubArrayAsJson(List<int> numbers)
{
    //E�er liste bo�sa veya null ise "[]" d�nd�r
    if (numbers == null || numbers.Count == 0) 
        return "[]";

    List<int> maxSubarray = new List<int>(); //Maksimum artan alt diziyi tutar.
    List<int> currentSubarray = new List<int> { numbers[0] }; //Ge�erli artan alt diziyi tutar.
    int maxSum = numbers[0]; //Maksimum alt dizinin toplam�n� tutar.
    int currentSum = numbers[0]; //Ge�erli alt dizinin toplam�n� tutar.

    //�kinci elemandan ba�layarak listeyi dola��r.
    for (int i = 1; i < numbers.Count; i++)
    {
        //E�er ge�erli eleman bir �nceki elemandan b�y�kse, ge�erli alt diziye ekle ve toplam� g�ncelle.
        if (numbers[i] > numbers[i - 1])
        {
            currentSubarray.Add(numbers[i]);
            currentSum += numbers[i];
        }
        else
        {
            //Art�� sona erdi�inde, e�er ge�erli toplam maksimum toplamdan b�y�kse, maksimum alt diziyi g�ncelle.
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                maxSubarray = new List<int>(currentSubarray);
            }
            //Yeni bir alt dizi ve ge�erli alt dizi toplam�n� ba�lat.
            currentSubarray = new List<int> { numbers[i] };
            currentSum = numbers[i];
        }
    }
    //D�ng� bittikten sonra, son alt dizi toplam�n� kontrol et.
    if (currentSum > maxSum)
    {
        //E�er ge�erli toplam maksimum toplamdan b�y�kse, maksimum alt diziyi g�ncelle.
        maxSubarray = new List<int>(currentSubarray);
    }

    //Maksimum artan alt diziyi JSON string olarak d�nd�r.
    return JsonSerializer.Serialize(maxSubarray);
}
