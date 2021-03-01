using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone_generator : MonoBehaviour
{
    public float sX = 10f;
    public float sY = 3f;
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
            num += 1;
            GeneratorCloud();
        }
    }

    public void GeneratorCloud()
    {
        GameObject findcam = GameObject.Find("Main Camera");
        RandomObj = Random.Range(0, 1);
        SpawnPos.y = Random.Range(-2.7f,-3.3f);
        SpawnPos.x = findcam.transform.position.x + sX;
        SpawnPos.z = -1.5f;
        Instantiate(SpawnObjects[RandomObj], SpawnPos, Quaternion.identity);
    }
}
