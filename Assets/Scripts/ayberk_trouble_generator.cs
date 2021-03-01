using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ayberk_trouble_generator : MonoBehaviour
{

    public float tX = 10f;
    public float tY = -2.72f;
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
            num += 13;
            GeneratorTrouble();
        }
    }

    public void GeneratorTrouble()
    {
        GameObject findcam = GameObject.Find("Main Camera");
        RandomObj = Random.Range(0, 2);
        SpawnPos.y = (tY);
        SpawnPos.x = findcam.transform.position.x + tX;
        SpawnPos.z = -1;
        Instantiate(SpawnObjects[RandomObj], SpawnPos, Quaternion.identity);
    }
}
