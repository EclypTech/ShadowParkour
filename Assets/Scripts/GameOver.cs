using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    [SerializeField] private Text overScore, overHighScore;
    private GameObject score, highScore;

    private int countCheck;

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject GameCanvas;
    [SerializeField] private GameObject VideoButton;
    private GameObject sound;
    private AudioSource soundAudioSource;
    private GameObject music;
    private AudioSource musicAudioSource;
    // Start is called before the first frame update
    void Start()
    {


        if (PlayerPrefs.GetInt("checkVideo") == 0)
        {
            VideoButton.SetActive(true);
            PlayerPrefs.SetInt("checkVideo", 1);
        }
        else
        {
            VideoButton.SetActive(false);
        }

        sound = GameObject.FindGameObjectWithTag("sound");
        soundAudioSource = sound.GetComponent<AudioSource>();
        music = GameObject.FindGameObjectWithTag("music");
        musicAudioSource = music.GetComponent<AudioSource>();

        
        musicAudioSource.Stop();
        soundAudioSource.Stop();

        countCheck = PlayerPrefs.GetInt("countCheck");
        countCheck += 1;
        PlayerPrefs.SetInt("countCheck", countCheck);
        mainCamera = GameObject.Find("Main Camera");
        score = GameObject.Find("Score");
        highScore = GameObject.Find("HighScore");

        overScore.text = score.GetComponent<Text>().text;
        overHighScore.text = highScore.GetComponent<Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseButton()
    {
        if(countCheck != 0 && (countCheck%2 == 0))
        {
            mainCamera.GetComponent<AdInter>().ShowInter();
        }
        else
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
        
        
    }

    public void OneChance()
    {
        Destroy(GameCanvas);
        Time.timeScale = 1;
    }
}
