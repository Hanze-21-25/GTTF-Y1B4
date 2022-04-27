using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad = "MainLevel";

    public void Play()
    {
        FindObjectOfType<AudioManager>().StopPlaying("MenuTheme");
        FindObjectOfType<AudioManager>().Play("LevelTheme");
        SceneManager.LoadScene(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}