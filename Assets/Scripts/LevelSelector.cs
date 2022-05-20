using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    //String to attach level names to specific buttons in level selection scene (second scene after starting the game)
    public void Select (string levelName)
    {
        FindObjectOfType<AudioManager>().StopPlaying("MenuTheme");
        FindObjectOfType<AudioManager>().Play("LevelTheme");
        SceneManager.LoadScene(levelName);


    }
}
