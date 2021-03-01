using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parkour_Generator : MonoBehaviour
{
    public Vector3 SpawnPos = new Vector3();
    public int num = 1;


    [SerializeField]
    public GameObject[] SpawnObjects;
    private int RandomObj;

    void Start()
    {
        SpawnPos.x = -5;

        for (int i = 0; i < 10; i++)
        {
            GeneratorParkour();

        }
    }

    void Update()
    {
        GameObject findcam = GameObject.Find("Main Camera");
        Score findscore = findcam.GetComponent<Score>();

        if (Mathf.RoundToInt(findscore.totalScore) == num)
        {
            num += 1;
            GeneratorParkour();
        }
    }

    public void GeneratorParkour()
    {
        SpawnObjects[RandomObj].transform.localScale = new Vector3(Random.Range(0.3f , 0.6f), 1, 1);

        GameObject findcam = GameObject.Find("Main Camera");
        RandomObj = Random.Range(0, 1);
        SpawnPos.y = Random.Range(-3.5f, -6f);
        SpawnPos.x += 5;
        SpawnPos.z = -1;
        Instantiate(SpawnObjects[RandomObj], SpawnPos, Quaternion.identity);
    }
}
