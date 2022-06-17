using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    //String to attach level names to specific buttons in level selection scene (second scene after starting the game)

    public Button[] levelButtons;

    void Start ()
    {

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;

        }
    }
    void Update()
    {
        if (Input.GetKeyDown("u"))
        {
            PlayerPrefs.SetInt("levelReached", 8);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown("l"))
        {
            PlayerPrefs.SetInt("levelReached", 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
        

public void Select (string levelName)
    {
        FindObjectOfType<AudioManager>().StopPlaying("MenuTheme");
        FindObjectOfType<AudioManager>().Play("LevelTheme");
        SceneManager.LoadScene(levelName);


    }
}
