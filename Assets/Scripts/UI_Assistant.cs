using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Assistant : MonoBehaviour
{

    private Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private AudioSource talkingAudioSource;
    private int counter = 0;
    public GameObject cutsceneNextUI;

    string[] messageArray = new string[] {
                        "Okay human, I heard from General X that you should be able to help us fight this war.",
                        "I heard that you humans use these things called names, what's your's?",
                        "To be honest, I'm not a big fan of the General's decision to put you in charge.  It's you humans who started this whole thing in the first place!",
                        "But General X was a great X, he was a great leading figure for all of us animals.",
                        "I trust he had his reasons in choosing you.",
                        "Here, let me show you the basics.",
                        "There are straggling plastic bottles from the previous battle that you can help us get rid of.", };

    private void Awake()

    {
        for (int i = 0; i < messageArray.Length; i++)
        {

            messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
            talkingAudioSource = transform.Find("talkingSound").GetComponent<AudioSource>();

            transform.Find("message").GetComponent<Button_UI>().ClickFunc = () =>
            {
                if (textWriterSingle != null && textWriterSingle.IsActive())
                {
                    // Currently active TextWriter
                    textWriterSingle.WriteAllAndDestroy();
                }
                if (counter < messageArray.Length)
                {
                    string message = messageArray[counter];
                    Debug.Log(counter + " , " + messageArray.Length);
                    StartTalkingSound();
                    textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .02f, true, true, StopTalkingSound);
                    counter++;
                }
                else
                {
                    cutsceneNextUI.SetActive(true);
                }
            };

              
        };
        
    }

    private void StartTalkingSound()
    {
    talkingAudioSource.Play();
    }

     private void StopTalkingSound()
     {
     talkingAudioSource.Stop();
     }

    private void Start()
    {
        talkingAudioSource.Stop();
        //TextWriter.AddWriter_Static(messageText, "This is the assistant speaking, hello and goodbye, see you next time!", .1f, true);
    }

}