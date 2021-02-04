using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    public List<CamionParLigne> myList = new List<CamionParLigne>();

    public float radius = 1;
    public Vector2 regionSize = Vector2.one;
    public int rejectionSamples = 30;
    public float displayRadius = 1;
    public List<Vector2> points;

    void Start()
    {
       mytest(CSVReaderBehaviours.readCSV());
       points = PoissonDiscSampling.GeneratePoints(radius, regionSize, rejectionSamples);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (CamionParLigne item in myList)
            {
                if(item.time == "2020")
                {
                    Debug.Log(item.ProduitsAgricoltes);
                    Debug.Log(item.Industrie);
                    Debug.Log(item.ServiceMarchands);
                    Debug.Log(item.ServiceNonMarchands);
                    Debug.Log(item.CorrectionTerritoriale);
                }
            }

            
        }
    }

    public CamionParLigne getCamion(string date)
    {
        foreach (CamionParLigne item in myList)
        {
            if (item.time == date)
            {
                return item;
            }
        }
        return null;
    }

    void mytest(List<CamionParLigne> list)
    {
        float ProduitsAgricoltes = 0;
        float Industrie = 0;
        float ServiceMarchands = 0;
        float ServiceNonMarchands = 0;
        float CorrectionTerritoriale = 0;


        for (int i = 1; i < list.Count; i++)
        {
            if(list[i].time == list[i - 1].time)
            {
                ProduitsAgricoltes += list[i-1].ProduitsAgricoltes;
                Industrie += list[i - 1].Industrie;
                ServiceMarchands += list[i - 1].ServiceMarchands;
                ServiceNonMarchands += list[i - 1].ServiceNonMarchands;
                CorrectionTerritoriale += list[i - 1].CorrectionTerritoriale;
            }
            else
            {
                ProduitsAgricoltes += list[i - 1].ProduitsAgricoltes;
                Industrie += list[i - 1].Industrie;
                ServiceMarchands += list[i - 1].ServiceMarchands;
                ServiceNonMarchands += list[i - 1].ServiceNonMarchands;
                CorrectionTerritoriale += list[i - 1].CorrectionTerritoriale;

                myList.Add(new CamionParLigne(list[i - 1].time, ProduitsAgricoltes, Industrie, ServiceMarchands, ServiceNonMarchands, CorrectionTerritoriale));
                
                ProduitsAgricoltes = 0;
                Industrie = 0;
                ServiceMarchands = 0;
                ServiceNonMarchands = 0;
                CorrectionTerritoriale = 0;

            }

        }
    }
}
