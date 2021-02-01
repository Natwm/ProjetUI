using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CanvasManager : MonoBehaviour
{
    public List<PoissonInterface> Spawner = new List<PoissonInterface>();
    public Slider slide;
    public test obj;

    public CamionParLigne camion;

    public TMP_Text date;

    public GameObject objGO;

    private Timer montimer;
    bool canMove;
    public AnimationCurve animation;

    public float speed = 2.5f;

    private float val;

    private void Start()
    {
        print(getDate());
        montimer = new Timer(2, UpdateCamion);
    }

    private void Update()
    {
        if (canMove)
        {
            val += Time.deltaTime;
            movela();
        }
        val = 0;
    }

    public void UpdateCamion()
    {

        getDate();
        foreach (PoissonInterface item in Spawner)
        {
            camion = obj.getCamion(getDate());
        }
        Debug.Log(camion.time);
        Debug.Log(camion.ProduitsAgricoltes);
        Debug.Log(camion.Industrie);
        Debug.Log(camion.ServiceMarchands);
        Debug.Log(camion.ServiceNonMarchands);
        Debug.Log(camion.CorrectionTerritoriale);

        foreach (var item in Spawner)
        {
            if(item.gameObject.transform.childCount > 0)
            {
                Destroy(item.gameObject.transform.GetChild(0).gameObject);
            }
            
        }

        Spawner[0].SpawnCamion(new Vector2(10, 50), Spawner[0].gameObject, Spawner[0].gameObject.transform.position, Spawner[0].radius, Spawner[0].testGO, (int)(camion.ProduitsAgricoltes*10));
        Spawner[1].SpawnCamion(new Vector2(10, 50), Spawner[1].gameObject, Spawner[1].gameObject.transform.position, Spawner[1].radius, Spawner[1].testGO, (int)(camion.Industrie * 10));
        Spawner[2].SpawnCamion(new Vector2(10, 50), Spawner[2].gameObject, Spawner[2].gameObject.transform.position, Spawner[2].radius, Spawner[2].testGO, (int)(camion.ServiceMarchands * 10));
        Spawner[3].SpawnCamion(new Vector2(10, 50), Spawner[3].gameObject, Spawner[3].gameObject.transform.position, Spawner[3].radius, Spawner[3].testGO, (int)(camion.ServiceNonMarchands * 10));
        Spawner[4].SpawnCamion(new Vector2(10, 50), Spawner[4].gameObject, Spawner[4].gameObject.transform.position, Spawner[4].radius, Spawner[4].testGO, (int)(camion.CorrectionTerritoriale * 10));
        canMove = false;
    }

    public void movela()
    {
        foreach (var item in Spawner)
        {
            for (int i = 0; i < item.gameObject.transform.GetChild(0).childCount; i++)
            {
                //item.gameObject.transform.GetChild(0).GetChild(i).transform.DOMoveX(item.gameObject.transform.GetChild(0).GetChild(i).transform.position.x-50, 2f);
                Vector3 newPos = new Vector3(item.gameObject.transform.GetChild(0).GetChild(i).transform.position.x - 100, item.gameObject.transform.GetChild(0).GetChild(i).transform.position.y, item.gameObject.transform.GetChild(0).GetChild(i).transform.position.z);
                item.gameObject.transform.GetChild(0).GetChild(i).transform.position = Vector3.Lerp(item.gameObject.transform.GetChild(0).GetChild(i).transform.position, newPos, animation.Evaluate(val*speed));
                print(animation.Evaluate(Time.deltaTime) * 50);
            }
        }
    }

    public void Up()
    {
        slide.value++;
        canMove = true;
        montimer.ResetPlay();
        //UpdateCamion();
    }

    public void Down()
    {
        slide.value--;
        UpdateCamion();
    }

    public void UpdateSlider()
    {
        getDate();
    }

    void UpdateDate(string newdate)
    {
        date.text = newdate;
    }

    public string getDate()
    {
        UpdateDate((slide.value + 1950).ToString());
        return (slide.value + 1950).ToString();
    }


}
