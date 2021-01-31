using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoissonInterface : MonoBehaviour
{
    GameObject leavesPS;
    public float radius;
    //public GameObject[] spawnOnpoint;
    //public Texture2D[] treeTexture;
    public int rejectionSamples = 30;
    public float minSize;
    public float maxSize;
    List<Vector2> points;
    Vector2 regionSize;
    bool Landmark;
    //public Sprite[] shrubs;

    public GameObject testGO;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnCamion(new Vector2(10, 50), gameObject, gameObject.transform.position, radius, testGO, 3);
    }
    public void LoadResources()
    {
        //spawnOnpoint = Resources.LoadAll<GameObject>("mesh/trees");
        //treeTexture = Resources.LoadAll<Texture2D>("textures/trees");

        //shrubs = Resources.LoadAll<Sprite>("sprite/shrubs");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            SpawnCamion(new Vector2(10,50),gameObject,gameObject.transform.position,radius,testGO,3);
        }
    }
    public GameObject ActualForest()
    {
        GameObject forest = new GameObject();
        forest.transform.SetPositionAndRotation(new Vector3(-1, -1, 0), forest.transform.rotation);
        forest.name = "Forest";
        //SpawnTrees(grid.farCorner, forest, gameObject.transform.position, 1.5f);
        return forest;
        
    }

    public void SpawnCamion(Vector2 inputSize,GameObject holder,Vector3 holderPosition,float radius, GameObject Camion, int amount)
    {
        int index = 0;
        regionSize = inputSize;
        points = PoissonDiscSampling.GeneratePoints(radius, regionSize, rejectionSamples);
        GameObject subholder = new GameObject();
        
        
        
        foreach (Vector2 item in points)
        {
            
            if(index < amount)
            {
                GameObject test;
                Vector3 translatedPos = new Vector3(item.x, item.y, 0);
                test = Instantiate(Camion);
                test.transform.SetPositionAndRotation(translatedPos, test.transform.rotation);
                test.transform.parent = subholder.transform;
                index++;
                //test.transform.localScale = new Vector3(size, size, 1);
                //test.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", treeTexture[randomTexture]);
                if (test.transform.childCount > 0)
                {
                    for (int i = 0; i < test.transform.childCount; i++)
                    {
                        //test.transform.GetChild(i).GetComponent<shrubRender>().setShrub();
                    }
                }
                test.transform.Rotate(Vector3.left, 90);
            }
            
            

            
            //test.transform.parent = subholder.transform;
            
        }
        
        subholder.transform.SetPositionAndRotation(holderPosition, subholder.transform.rotation);
        subholder.transform.parent = holder.transform;
    }

}
