using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CamionParLigne 
{
    public string time;
    public float ProduitsAgricoltes, Industrie, ServiceMarchands, ServiceNonMarchands, CorrectionTerritoriale;

    public CamionParLigne(string time,float ProduitsAgricoltes, float Industrie, float ServiceMarchands, float ServiceNonMarchands, float CorrectionTerritoriale)
    {
        this.time = time;
        this.ProduitsAgricoltes = ProduitsAgricoltes;
        this.Industrie = Industrie;
        this.ServiceMarchands = ServiceMarchands;
        this.ServiceNonMarchands = ServiceNonMarchands;
        this.CorrectionTerritoriale = CorrectionTerritoriale;
    }
}
