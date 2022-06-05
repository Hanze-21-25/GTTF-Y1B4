using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;


public class UI_Assistant : MonoBehaviour
{

    private Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private AudioSource talkingAudioSource;
    private int counter = 0;
    public GameObject cutsceneNextUI;
    private int sceneNumber;

    private void Awake()

    {
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
        List<string> messageList = new List<string>() { };
        switch (sceneNumber)
        {
            case 2:
                List<string> toAdd1 = new List<string>()
                {
                    "Okay human, I heard from General X that you should be able to help us fight this war.",
                    "I heard that you humans use these things called names, what's your's?",
                    "To be honest, I'm not a big fan of the General's decision to put you in charge.  It's you humans who started this whole thing in the first place!",
                    "But General X was a great X, he was a great leading figure for all of us animals.",
                    "I trust he had his reasons in choosing you.",
                    "Here, let me show you the basics.",
                    "There are straggling plastic bottles from the previous battle that you can help us get rid of."
                };
                messageList.AddRange(toAdd1);

                break;

                case 4:
                messageList.Clear();
                List<string> toAdd2 = new List<string>()
                {
                    "I saw you take care of those plastic bottles, great job!",
                    "But the plastic invasion is getting stronger and stronger! Many of our strongest Animals have been captured. Without them, we have no chance of defeating the pollution army!",
                    "My good friend Slimy Squid was taken by a group of humans to a restaurant not long ago.",
                    "We’re going to need his help if we want to deal with big groups of plastic!"
                };

                messageList.AddRange(toAdd2);
                break;

                case 5:
                messageList.Clear();
                List<string> toAdd3 = new List<string>()
                {
                    "Guys I need your help!",
                    "People are gonna eat me!",
                    "Carb and Seaturtle only you can help me!",
                   
                };

                messageList.AddRange(toAdd3);
                break;


                case 7:
                messageList.Clear();
                List<string> toAdd4 = new List<string>()
                {
                    "I got trapped by a fishing nest or My home got destroyed because of global warming!",
                    "And now I am here in Venice",
                    "Please help me!",

                };

                messageList.AddRange(toAdd4);
                break;
        }   

        for (int i = 0; i < messageList.Count; i++)
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
                if (counter < messageList.Count)
                {
                    string message = messageList[counter];
                    Debug.Log(counter + " , " + messageList.Count);
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