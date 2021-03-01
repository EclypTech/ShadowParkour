using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud_generator : MonoBehaviour
{

    public float cX = 10f;
    public float cY = 3f;
    public Vector3 SpawnPos = new Vector3();
    public int num = 10;


    [SerializeField]
    public GameObject[] SpawnObjects;
    private int RandomObj;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject findcam = GameObject.Find("Main Camera");
        Score findscore = findcam.GetComponent<Score>();

        if (Mathf.RoundToInt(findscore.totalScore) == num)
        {
            num += 3;
            GeneratorCloud();
        }
    }

    public void GeneratorCloud()
    {
        GameObject findcam = GameObject.Find("Main Camera");
        RandomObj = Random.Range(0, 2);
        SpawnPos.y = Random.Range(3.5f, 2.5f);
        SpawnPos.x = findcam.transform.position.x + cX;
        SpawnPos.z = -2;
        Instantiate(SpawnObjects[RandomObj], SpawnPos, Quaternion.identity);
    }
}
