
using UnityEngine;
using TMPro;

public class ModalManager : MonoBehaviour
{
    public GameObject modalWindow;
    public TextMeshProUGUI header;
    public TextMeshProUGUI body;

    public static ModalManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    //Sets active the modal window to display it
    public void ShowModal(string header, string body)
    {
        this.header.text = header;
        this.body.text = body;
        
        modalWindow.SetActive(true);
    }
    //Hides the modal window
    public void HideModal()
    {
        modalWindow.SetActive(false);
        
    }

}
