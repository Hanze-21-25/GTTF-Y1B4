
using UnityEngine;

public class Tester : MonoBehaviour
{
    //Tutorial and tips to display in the modal window
    private string[] messages = {
        "Use WASD or Arrow Keys to move around.",
        "Use Q/E or Middle Mouse Wheel to rotate.",
        "Scroll Mouse Wheel to zoom in & out.",
        "Use Left Mouse Button to place an animal.",
        "Don't let the trash reach the ocean. Save the ocean, help animals protect their home!",

        };

    //Displays the message in the modal window the the button Tutorial Tips is pressed
    public void GetNewMessage()
    {
        //Reference to the ModalManager
        ModalManager.instance.ShowModal("Tutorial Tips", messages[Random.Range(0, messages.Length)]);
    }
}
