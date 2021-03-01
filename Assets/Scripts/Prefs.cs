using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prefs : MonoBehaviour
{

    [SerializeField] private Text highScore;
    [SerializeField] private GameObject music;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("highScore");
        PlayerPrefs.GetFloat("musicLevel");
        PlayerPrefs.GetFloat("soundLevel");
        music = GameObject.FindGameObjectWithTag("music");
        
        music.GetComponent<AudioSource>().Play();

        highScore.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
