using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{   
    
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
     public AudioSource gameAudio;
     public AudioSource pauseAudio;
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {

            if(GameIsPaused)
            {
                Resume();
                pauseAudio.Play();
            }
            else
            {
                Pause();
                pauseAudio.Play();
            }
        }
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameAudio.Pause();
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameAudio.Play();
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
     public void GoMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
