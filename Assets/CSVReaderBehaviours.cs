using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CSVReaderBehaviours 
{
    public static List<CamionParLigne> readCSV()
    {
        List<CamionParLigne> test = new List<CamionParLigne>();
        int compteur = 0;
        string ligne;

        char split = ';';

        System.IO.StreamReader fichier = new System.IO.StreamReader(@"Assets\Feuille_de_calcul_sans_titre_-_Feuille_1.csv");
        Debug.Log("fichier");
        while (( ligne = fichier.ReadLine()) != null)
        {
            string[] substring = ligne.Split(split);
            //Debug.Log(float.Parse("2,3"));
            test.Add(new CamionParLigne(substring[0].Split('-')[0], float.Parse(substring[1]), float.Parse(substring[2]), float.Parse(substring[3]), float.Parse(substring[4]), float.Parse(substring[5])));
            compteur++;
        }
        return test;
    }

}
