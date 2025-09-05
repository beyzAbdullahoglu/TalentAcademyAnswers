
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;


public static string MaxIncreasingSubArrayAsJson(List<int> numbers)
{
    //Eðer liste boþsa veya null ise "[]" döndür
    if (numbers == null || numbers.Count == 0) 
        return "[]";

    List<int> maxSubarray = new List<int>(); //Maksimum artan alt diziyi tutar.
    List<int> currentSubarray = new List<int> { numbers[0] }; //Geçerli artan alt diziyi tutar.
    int maxSum = numbers[0]; //Maksimum alt dizinin toplamýný tutar.
    int currentSum = numbers[0]; //Geçerli alt dizinin toplamýný tutar.

    //Ýkinci elemandan baþlayarak listeyi dolaþýr.
    for (int i = 1; i < numbers.Count; i++)
    {
        //Eðer geçerli eleman bir önceki elemandan büyükse, geçerli alt diziye ekle ve toplamý güncelle.
        if (numbers[i] > numbers[i - 1])
        {
            currentSubarray.Add(numbers[i]);
            currentSum += numbers[i];
        }
        else
        {
            //Artýþ sona erdiðinde, eðer geçerli toplam maksimum toplamdan büyükse, maksimum alt diziyi güncelle.
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                maxSubarray = new List<int>(currentSubarray);
            }
            //Yeni bir alt dizi ve geçerli alt dizi toplamýný baþlat.
            currentSubarray = new List<int> { numbers[i] };
            currentSum = numbers[i];
        }
    }
    //Döngü bittikten sonra, son alt dizi toplamýný kontrol et.
    if (currentSum > maxSum)
    {
        //Eðer geçerli toplam maksimum toplamdan büyükse, maksimum alt diziyi güncelle.
        maxSubarray = new List<int>(currentSubarray);
    }

    //Maksimum artan alt diziyi JSON string olarak döndür.
    return JsonSerializer.Serialize(maxSubarray);
}
