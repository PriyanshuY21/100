using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager levelManager;

    private int currentPoints = 0;
    private int highscore;
    public GameObject bronze;
    public GameObject silver;
    public GameObject gold;

    public Text pointsText;

    public AudioSource pointAudio;
    public AudioSource specialAudio;
    public GameObject endMenu;

   void Start()
    {
        bronze.SetActive(false);
        silver.SetActive(false);
        gold.SetActive(false);
    }

    void Awake()
    {
        if (levelManager == null)
        {
            levelManager = this;
            highscore = PlayerPrefs.GetInt("Highscore");

            GetAudioPreferences();
        }
        else if (levelManager != this)
        {
            Destroy(gameObject);
        }
    }

    private void GetAudioPreferences()
    {
        float appVolume = PlayerPrefs.GetFloat("Volume");
        appVolume = appVolume == 0f ? 0.5f : appVolume;

        specialAudio.volume = appVolume;
        pointAudio.volume = appVolume;
    }

    public void UpdatePoints()
    {
        currentPoints++;
        pointsText.text = currentPoints.ToString();
        if(currentPoints <= 5)
        {
            bronze.SetActive(true);
        }
        else if(currentPoints > 5 && currentPoints <= 10) 
        {
            bronze.SetActive(false);
            silver.SetActive(true);
        }
        else if(currentPoints > 10)
        {
            silver.SetActive(false);
            gold.SetActive(true);
        }
        if ((currentPoints % 10 == 0 && currentPoints != 10)|| currentPoints == 6 || currentPoints == 11)
        {
            specialAudio.Play();
        }
        else
        {
            pointAudio.Play();
        }
    }

    public void UpdateHighscore()
    {
        if (currentPoints > highscore)
        {
            highscore = currentPoints;
            PlayerPrefs.SetInt("Highscore", highscore);
        }
    }

    public void OpenEndMenu()
    {
        Time.timeScale = 0;
        UpdateHighscore();
        endMenu.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
