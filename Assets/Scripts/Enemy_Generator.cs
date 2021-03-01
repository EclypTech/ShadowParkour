using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Generator : MonoBehaviour
{
    public float rX = 10f;
    public float rY = -2.1f;
    public Vector3 SpawnPos = new Vector3();
    public int num = 10;


    [SerializeField]
    public GameObject[] SpawnObjects;
    private int RandomObj;



    void Start()
    {
        
    }


    void Update()
    {
        GameObject findcam = GameObject.Find("Main Camera");
        Score findscore = findcam.GetComponent<Score>();

        if (Mathf.RoundToInt(findscore.totalScore) == num)
        {
            num += 4;
            GeneratorEnemy();
        }
    }

    public void GeneratorEnemy()
    {
        GameObject findcam = GameObject.Find("Main Camera");
        RandomObj = Random.Range(0, 4);
        SpawnPos.y = (rY);
        SpawnPos.x = findcam.transform.position.x + rX;
        SpawnPos.z = -2;
        Instantiate(SpawnObjects[RandomObj], SpawnPos, Quaternion.identity);
    }
}
