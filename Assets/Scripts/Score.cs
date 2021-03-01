using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField] private Text score;
    [SerializeField] private Text highScoreText;
    public float totalScore;
    private int highScore;
    private int checkVideo = 0;
    // Start is called before the first frame update

    private void Start()
    {   
        if(checkVideo == 0)
        {
            PlayerPrefs.SetInt("checkVideo", 0);
            checkVideo = 1;
        }
        else
        {
            PlayerPrefs.SetInt("checkVideo", 1);
        }
        highScore = PlayerPrefs.GetInt("highScore");
    }
    // Update is called once per frame
    void Update()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        totalScore += 4 * Time.deltaTime;
        score.text = (Mathf.RoundToInt(totalScore)).ToString();
        highScoreText.text = highScore.ToString();

        if (totalScore > highScore)
        {
            PlayerPrefs.SetInt("highScore", Mathf.RoundToInt(totalScore));
            highScoreText.text = (Mathf.RoundToInt(totalScore)).ToString();
        }
    }
}
