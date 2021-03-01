using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject GamePlayCanvas;
    [SerializeField] private GameObject GameOverPanel;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Time.timeScale = 0;
            Destroy(collision.gameObject);
            (Instantiate(GameOverPanel, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject).transform.SetParent(GamePlayCanvas.transform);
        }
    }
}
