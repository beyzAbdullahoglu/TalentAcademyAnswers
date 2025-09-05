using System.Linq;
using System.Text.Json;
using System.Collections.Generic;


public static string LongestVowelSubsequenceAsJson(List<string> words)
{
    //T�m sesli harfleri tan�mla.
    var vowels = "aeiouAEIOU";

    //Sonu�lar� depolamak i�in bir liste olu�tur.
    var result = new List<object>();

    //Her kelimeyi s�rayla i�le.
    foreach (var word in words)
    {
        string maxSeq = ""; //En uzun sesli harf dizisini tutar.
        string currentSeq = ""; //Ge�erli sesli harf dizisini tutar.

        foreach (var ch in word) //Her karakteri s�rayla i�le.
        {
            if (vowels.Contains(ch))
            {
                currentSeq += ch; //E�er karakter sesli harf dizisinde varsa, ge�erli diziyi g�ncelle.
                if (currentSeq.Length > maxSeq.Length) //En uzun diziyi g�ncelle.
                    maxSeq = currentSeq;
            }
            else
            {
                currentSeq = ""; //Sessiz harf veya ba�ka karakterle kar��la��ld���nda ge�erli diziyi s�f�rla.
            }
        }
        //Her kelime i�in JSON format�nda sonuca ekle.
        result.Add(new
        {
            word = word,
            sequence = maxSeq,
            length = maxSeq.Length
        });
    }
    //Sonu�lar� JSON stringine d�n��t�r ve d�nd�r.
    return JsonSerializer.Serialize(result);
}

  