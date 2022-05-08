using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        FindObjectOfType<AudioManager>().StopPlaying("MenuTheme");
        FindObjectOfType<AudioManager>().Play("LevelTheme");
        SceneManager.LoadScene("MainLevel");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}