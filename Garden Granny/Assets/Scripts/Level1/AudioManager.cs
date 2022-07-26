using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Use this in other scripts to play a sound when something happens - FindObjectOfType<AudioManager>().Play("HitFly");
    //HitFly sound triggered in Player Attack script. Theme sound triggered on start.

    //Use this to stop sounds cutting eachother off - FindObjectOfType<AudioManager>().IsThisSoundPlaying(int soundIndex);

    public static AudioManager instance;
    public Sound[] sounds;
    private AudioSource soundPlaying;

    private void Awake()
    {

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Theme");

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Destroyed Extra " + this.name);
            return;
        }
        DontDestroyOnLoad(this.gameObject);

    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    
    public bool IsThisSoundPlaying(int soundIndex)
    {
        soundPlaying = sounds[soundIndex].source;
        if(soundPlaying.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
