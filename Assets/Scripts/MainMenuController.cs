using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MainMenuController : MonoBehaviour
{
    [FormerlySerializedAs("OptionPanel")] public GameObject optionPanel;
    [FormerlySerializedAs("MenuPanel")] public GameObject menuPanel;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(true);
        optionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToOptionPanel()
    {
        menuPanel.SetActive(false);
        optionPanel.SetActive(true);
    }
    
    public void Back()
    {
        menuPanel.SetActive(true);
        optionPanel.SetActive(false);
    }

    public void PlayGame(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); //for debug

    }
}
