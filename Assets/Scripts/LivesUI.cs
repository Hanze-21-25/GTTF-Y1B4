using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public Text livesText;
 
    // Update is called once per frame
    void Update()
    {
        livesText.text = Player.Lives.ToString() + " LIVES";
    }
}
