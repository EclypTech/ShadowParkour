using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject music;
    [SerializeField] private GameObject sound;
    [SerializeField] private AudioClip buttonSound;
    [SerializeField] private GameObject musicOpenButton;
    [SerializeField] private GameObject musicClosedButton;
    [SerializeField] private GameObject soundOpenButton;
    [SerializeField] private GameObject soundClosedButton;
    [SerializeField] private int sceneId;


    public int initCheck;


    private void Start()
    {
        initCheck = PlayerPrefs.GetInt("initCheck");
        //Ses objeleri tag ile çekildi.
        music = GameObject.FindGameObjectWithTag("music");
        sound = GameObject.FindGameObjectWithTag("sound");
        

        if (initCheck == 0)
        {
            music.GetComponent<AudioSource>().volume = 0.2f;
            sound.GetComponent<AudioSource>().volume = 1;

            musicOpenButton.SetActive(true);
            musicClosedButton.SetActive(false);

            soundOpenButton.SetActive(true);
            soundClosedButton.SetActive(false);

            PlayerPrefs.SetInt("initCheck",1);
        }
        else
        {
            if(PlayerPrefs.GetFloat("musicLevel") > 0)
            {
                music.GetComponent<AudioSource>().volume = 0.2f;
                musicOpenButton.SetActive(true);
                musicClosedButton.SetActive(false);

            }
            else
            {
                music.GetComponent<AudioSource>().volume = 0;
                musicClosedButton.SetActive(true);
                musicOpenButton.SetActive(false);
            }

            if (PlayerPrefs.GetFloat("soundLevel") > 0)
            {
                sound.GetComponent<AudioSource>().volume = 1;
                soundOpenButton.SetActive(true);
                soundClosedButton.SetActive(false);
            }
            else
            {
                sound.GetComponent<AudioSource>().volume = 0;
                soundClosedButton.SetActive(true);
                soundOpenButton.SetActive(false);
            }


        }

        
    }

    public void Settings()
    {
        Time.timeScale = 0;
        SettingsPanel.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene(sceneId);
        Time.timeScale = 1;
    }

    public void Close()
    {
        SettingsPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void WatchVideo()
    {

    }

    public void MusicClose()
    {
        music.GetComponent<AudioSource>().volume = 0;
        PlayerPrefs.SetFloat("musicLevel",0);
        musicClosedButton.SetActive(true);
        musicOpenButton.SetActive(false);

    }

    public void MusicOpen()
    {
        music.GetComponent<AudioSource>().volume = 0.2f;
        PlayerPrefs.SetFloat("musicLevel", 0.2f);
        musicOpenButton.SetActive(true);
        musicClosedButton.SetActive(false);
    }

    public void soundClose()
    {
        sound.GetComponent<AudioSource>().volume = 0;
        PlayerPrefs.SetFloat("soundLevel", 0);
        soundClosedButton.SetActive(true);
        soundOpenButton.SetActive(false);
    }

    public void SoundOpen()
    {
        sound.GetComponent<AudioSource>().volume = 1;
        PlayerPrefs.SetFloat("soundLevel", 1);
        soundOpenButton.SetActive(true);
        soundClosedButton.SetActive(false);
    }

    public void ButtonSound()
    {
        sound.GetComponent<AudioSource>().PlayOneShot(buttonSound);
    }

}
