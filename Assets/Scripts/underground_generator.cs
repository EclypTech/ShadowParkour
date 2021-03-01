using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class underground_generator : MonoBehaviour
{
    public float uX = 10f;
    public float uY = -3f;
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
            num += 2;
            GeneratorUnderground();
        }

    }

    public void GeneratorUnderground()
    {
        GameObject findcam = GameObject.Find("Main Camera");
        RandomObj = Random.Range(0, 5);
        SpawnPos.y = Random.Range(-4,-6);
        SpawnPos.x = findcam.transform.position.x + uX;
        SpawnPos.z = -2;
        Instantiate(SpawnObjects[RandomObj], SpawnPos, Quaternion.identity);
    }
}
