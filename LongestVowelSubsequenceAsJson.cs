using System.Linq;
using System.Text.Json;
using System.Collections.Generic;


public static string LongestVowelSubsequenceAsJson(List<string> words)
{
    //Tüm sesli harfleri tanýmla.
    var vowels = "aeiouAEIOU";

    //Sonuçlarý depolamak için bir liste oluþtur.
    var result = new List<object>();

    //Her kelimeyi sýrayla iþle.
    foreach (var word in words)
    {
        string maxSeq = ""; //En uzun sesli harf dizisini tutar.
        string currentSeq = ""; //Geçerli sesli harf dizisini tutar.

        foreach (var ch in word) //Her karakteri sýrayla iþle.
        {
            if (vowels.Contains(ch))
            {
                currentSeq += ch; //Eðer karakter sesli harf dizisinde varsa, geçerli diziyi güncelle.
                if (currentSeq.Length > maxSeq.Length) //En uzun diziyi güncelle.
                    maxSeq = currentSeq;
            }
            else
            {
                currentSeq = ""; //Sessiz harf veya baþka karakterle karþýlaþýldýðýnda geçerli diziyi sýfýrla.
            }
        }
        //Her kelime için JSON formatýnda sonuca ekle.
        result.Add(new
        {
            word = word,
            sequence = maxSeq,
            length = maxSeq.Length
        });
    }
    //Sonuçlarý JSON stringine dönüþtür ve döndür.
    return JsonSerializer.Serialize(result);
}

  