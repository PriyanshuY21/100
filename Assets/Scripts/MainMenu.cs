using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highscoreCount;
    public GameObject bronze;
    public GameObject silver;
    public GameObject gold;


    void Awake()
    {
         bronze.SetActive(false);
        silver.SetActive(false);
        gold.SetActive(false);
        if (!PlayerPrefs.HasKey("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", 0);
        }
        int highscore = PlayerPrefs.GetInt("Highscore");
        highscoreCount.text = highscore.ToString();
        int highscoreValue = int.Parse(highscoreCount.text);
        if (highscoreValue <= 5)
       {
         bronze.SetActive(true);
       }
        else if (highscoreValue > 5 && highscoreValue <= 10)
       {
         bronze.SetActive(false);
         silver.SetActive(true);
        }
        else if (highscoreValue > 10)
        {
        silver.SetActive(false);
        gold.SetActive(true);
        }  
    }

    public void PlayGame()
    {
       SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeVolume(float value)
    {
        PlayerPrefs.SetFloat("Volume", value);
    }
}
