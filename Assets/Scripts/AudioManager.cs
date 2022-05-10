using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] Sounds;

    public static AudioManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in Sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;
            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;

        }

    }

    public void StopPlaying(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.name == name);
        s.Source.Stop();
    }

    void Start()
    {
        Play("MenuTheme");
    }


    public void Play (string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.name == name);
        s.Source.Play();

    }


}
