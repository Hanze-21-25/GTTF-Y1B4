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
                    "Okay human, I heard from General Jellyfish that you should be able to help us fight this war.",
                    "To be honest, I'm not a big fan of the General's decision to put you in charge. It's you humans who started this whole thing in the first place!",
                    "But General Jellyfish was a great Jellyfish, he was a great leading figure for all of us animals.",
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
                    "I saw you take care of those plastic straws, great job!",
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
                    "Humans caught me and now I’m in this bucket",
                    "They are gonna cook and eat me!",
                    "I need your help to destroy all of their plastic waste to escape this place!",
                    
                };

                messageList.AddRange(toAdd3);
                break;


                case 7:
                messageList.Clear();
                List<string> toAdd4 = new List<string>()
                {
                    "Hello Human!",
                    "My home, Iceberg!",
                    "It got destroyed because of global warming!",
                    "And now I am here in Venice",
                    "Trapped by a fishing net",
                    "Arriving plastic makes it hard to breathe in this net",
                    "Can you please defeat all the plastic and free me out of this fishing net?",
                    
                };

                messageList.AddRange(toAdd4);
                break;

                case 9:
                messageList.Clear();
                List<string> toAdd5 = new List<string>()
                {
                    "Hey human, what are you doing here?",
                    "Are you here to pollute the city again?",
                    "Streets of the city are so polluted that people had to organize a World Clean Up Day",
                    "World Clean Up Day is THE BIGGEST GLOBAL CLEANUP OF THE YEAR!",
                    "World Cleanup Day unites millions of volunteers, governments and organisations in one hundred ninety-one countries around the world.",
                    "You also can join World Clean Up Day and save the world today!",

                };

                messageList.AddRange(toAdd5);
                break;
            
                case 11:
                messageList.Clear();
                List<string> toAdd6 = new List<string>()
                {
                    "There is a big explosion on the Oil Rig in the middle of the ocean. The world needs animals to save it from pollution",
                    
                   


                };

                messageList.AddRange(toAdd6);
                break;


            case 13:
                messageList.Clear();
                List<string> toAdd7 = new List<string>()
                {
                    "G'day mate, I need ya help!",
                    "That bloody plastic is ruining our arvo, can ya defeat them, mate.",




                };

                messageList.AddRange(toAdd7);
                break;

            case 16:
                messageList.Clear();
                List<string> toAdd8 = new List<string>()
                {
                    "Thank you human for helping us out in this war",
                    "There is still so much to do to defeat the plastic",
                    "Make sure to check out World Clean Up Day!",
                    "We will continue fightning the plastic",
                    






                };

                messageList.AddRange(toAdd8);
                break;
        }

        //

        messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
        talkingAudioSource = transform.Find("talkingSound").GetComponent<AudioSource>();
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



        //
        for (int i = 1; i < messageList.Count; i++)
        {

            messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
            talkingAudioSource = transform.Find("talkingSound").GetComponent<AudioSource>();

            transform.Find("message").GetComponent<Button_UI>().ClickFunc = () =>
            {
                if (textWriterSingle != null && textWriterSingle.IsActive())
                {
                    // Currently active TextWriter
                    textWriterSingle.WriteAllAndDestroy();
                    StopTalkingSound();
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
        //talkingAudioSource.Stop();
        //TextWriter.AddWriter_Static(messageText, "This is the assistant speaking, hello and goodbye, see you next time!", .1f, true);
    }

}