using Pars2012;
using System.Collections.Generic;
//2-4
List<string> sorok = File.ReadAllLines("Selejtezo2012.txt").ToList();
List<Versenyző> versenyzők = new();
foreach (string sor in sorok)
{
    versenyzők.Add(new Versenyző(sor));
}
versenyzők.RemoveAt(0);

//5
Console.WriteLine($"5. feladat: Versenyzők száma a selejtezőben: {versenyzők.Count} fő");

//6
int autoTovabbJutott = 0;
foreach (Versenyző versenyző in versenyzők)
{
    if (versenyző.D1 > 78 || versenyző.D2 > 78)
    {
        autoTovabbJutott++;
    }
}
Console.WriteLine($"6. feladat: 78,00 méter feletti eredménnyel továbbjutott: {autoTovabbJutott} fő");

//7
foreach (Versenyző versenyző in versenyzők)
{
    double temp_Eredmeny = Math.Max(versenyző.D1, Math.Max(versenyző.D2, versenyző.D3));
    if(temp_Eredmeny < 0)
    {
        temp_Eredmeny = -1.0;
    }
    versenyző.Eredmény = temp_Eredmeny;
}

//8
foreach (Versenyző versenyző in versenyzők)
{
    versenyző.Nemzet = versenyző.NemzetÉsKód.Split('(')[0].Trim();
    versenyző.Kód = versenyző.NemzetÉsKód.Split('(')[1].Split(')')[0];
}

//9
Versenyző legjobbVersenyző = versenyzők[0];
foreach (Versenyző versenyző in versenyzők)
{
    if(versenyző.Eredmény>legjobbVersenyző.Eredmény)
    {
        legjobbVersenyző = versenyző;
    }
}
Console.WriteLine("9. Feladat: A selejtező nyertese:");
Console.WriteLine($"\tNév: {legjobbVersenyző.Név}");
Console.WriteLine($"\tCsoport: {legjobbVersenyző.Csoport}");
Console.WriteLine($"\tNemzet: {legjobbVersenyző.Nemzet}");
Console.WriteLine($"\tNemzet kód: {legjobbVersenyző.Kód}");
string temp_d3eredmeny = legjobbVersenyző.D3.ToString();
if (temp_d3eredmeny == "-1")
{
    temp_d3eredmeny = "X";
}
else if (temp_d3eredmeny == "-2")
{
    temp_d3eredmeny = "-";
}
Console.WriteLine($"\tSorozat: {legjobbVersenyző.D1};{legjobbVersenyző.D2};{temp_d3eredmeny}");
Console.WriteLine($"\tEredmény: {legjobbVersenyző.Eredmény}");

//10
List<string> fileAdatok =  new List<string>();
fileAdatok.Add("Helyezés;Név;Csoport;NemzetKód;Sorozat;Eredmény");

var temp_Versenyzők = versenyzők;
for (int i = 1; i < 13; i++)
{
    Versenyző legjobbEddigiVersenyző = temp_Versenyzők[0];
    foreach (Versenyző versenyző in temp_Versenyzők)
    {
        if (versenyző.Eredmény > legjobbEddigiVersenyző.Eredmény)
        {
            legjobbEddigiVersenyző = versenyző;
        }
    }
    string temp_d1eredmeny = legjobbEddigiVersenyző.D1.ToString();
    string temp_d2eredmeny = legjobbEddigiVersenyző.D2.ToString();
    temp_d3eredmeny = legjobbEddigiVersenyző.D3.ToString();
    if (temp_d1eredmeny == "-1")
    {
        temp_d1eredmeny = "X";
    }
    else if (temp_d1eredmeny == "-2")
    {
        temp_d1eredmeny = "-";
    }
    if (temp_d2eredmeny == "-1")
    {
        temp_d2eredmeny = "X";
    }
    else if (temp_d2eredmeny == "-2")
    {
        temp_d2eredmeny = "-";
    }
    if (temp_d3eredmeny == "-1")
    {
        temp_d3eredmeny = "X";
    }
    else if (temp_d3eredmeny == "-2")
    {
        temp_d3eredmeny = "-";
    }
    fileAdatok.Add($"{i};{legjobbEddigiVersenyző.Név};{legjobbEddigiVersenyző.Csoport};{legjobbEddigiVersenyző.Nemzet};{legjobbEddigiVersenyző.Kód};{temp_d1eredmeny};{temp_d2eredmeny};{temp_d3eredmeny};{legjobbEddigiVersenyző.Eredmény}");

    temp_Versenyzők.Remove(legjobbEddigiVersenyző);
}
File.WriteAllLines("Dontos2012.txt",fileAdatok.ToArray());