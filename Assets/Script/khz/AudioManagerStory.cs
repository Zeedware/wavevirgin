using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerStory : MonoBehaviour {
    AudioSource source;

    public AudioClip story1;
    public AudioClip story2;
    public AudioClip story3;
    public AudioClip story4;
    public AudioClip story5;
    public AudioClip story6;
    public AudioClip story7;
    public AudioClip story8;
    public AudioClip story9;
    // Use this for initialization

    private static AudioManagerStory instance;

    public static AudioManagerStory Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();

    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   
    public void playSound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
    public void playStory(int x)
    {
        AudioClip played;
        if (x == 1)
        {
            played = story1;
        }else if (x == 2)
        {
            played = story2;
        }
        else if (x == 3)
        {
            played = story3;
        }
        else if (x == 4)
        {
            played = story4;
        }
        else if (x == 5)
        {
            played = story5;
        }
        else if (x == 6)
        {
            played = story6;
        }
        else if (x == 7)
        {
            played = story7;
        }
        else if (x == 8)
        {
            played = story8;
        }
        else
        {
            played = story9;
        }

        playSound(played);
    }
}
