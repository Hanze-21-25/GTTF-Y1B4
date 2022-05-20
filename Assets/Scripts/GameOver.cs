using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;


    private void Start()
    {
        Time.timeScale = 0f;
    }
    void OnEnable ()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Next (string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void Retry ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<AudioManager>().Play("MenuTheme");
        FindObjectOfType<AudioManager>().StopPlaying("LevelTheme");
    }
}
