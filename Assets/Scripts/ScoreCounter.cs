using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) // When triggered Collider..
    {
        if (collision.transform.tag == "Player")               // If triggered collision tag is Player..
        {
            Debug.Log("triggered");

            GameObject findcam = GameObject.Find("Main Camera");
            Score findscore = findcam.GetComponent<Score>();
            findscore.totalScore += 1;

            gameObject.GetComponent<BoxCollider2D>().enabled = false;


            //collision.GetComponent<Score>().totalScore += 1;    // Add 1 point to the score which located Generator.cs
            //GetComponent<BoxCollider2D>().enabled = false;     // Close the box collider for increase the score 1 point each time.
        }
    }
}
