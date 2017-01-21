using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    AudioSource source;
    public AudioSource quakeSource;
    
    public AudioClip cewekCorrect1;
    public AudioClip cewekCorrect2;
    public AudioClip cewekCorrect3;
    public AudioClip cewekCorrect4;
    public AudioClip cewekCorrect5;

    public AudioClip cewekWrong1;

    public AudioClip cewekBuang1;

    public AudioClip priaCorrect1;
    public AudioClip priaCorrect2;

    public AudioClip priaWrong1;

    public AudioClip priaBuang1;

    public AudioClip omWrong1;

    public AudioClip omBuang1;

    public AudioClip tanteWrong1;

    public AudioClip tanteBuang1;
    // Use this for initialization

    private static AudioManager instance;

    public static AudioManager Instance
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
    public void playSfx(string input)
    {
        int rand;
        if (input.Equals("cewekcorrect"))
        {
            playCewekCorrect();
        }
        else if (input.Equals("cewekwrong"))
        {
            playCewekWrong();
        }
        else if (input.Equals("cewekbuang"))
        {
            playCewekBuang();
        }
        else if (input.Equals("priacorrect"))
        {
            playPriaCorrect();
        }
        else if (input.Equals("priawrong"))
        {
            playPriaWrong();
        }
        else if (input.Equals("priabuang"))
        {
            playPriaBuang();
        }else if (input.Equals("omwrong"))
        {
            playOmWrong();
        }
        else if (input.Equals("ombuang"))
        {
            playOmBuang();
        }
        else if (input.Equals("tantewrong"))
        {
            playTanteWrong();
        }
        else if (input.Equals("tantebuang"))
        {
            playTanteBuang();
        }else if (input.Equals("quake"))
        {
            playQuake();
        }

    }
    public void playSound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }

    public void playCewekCorrect()
    {
        int rand = (int)Random.Range(0, 5);
        switch (rand)
        {
            case 0:
                playSound(cewekCorrect1);
                break;
            case 1:
                playSound(cewekCorrect2);
                break;
            case 2:
                playSound(cewekCorrect3);
                break;
            case 3:
                playSound(cewekCorrect4);
                break;
            case 4:
                playSound(cewekCorrect5);
                break;
        }
    }
    public void playCewekWrong()
    {
        int rand = (int)Random.Range(0, 0);
        switch (rand)
        {
            case 0:
                playSound(cewekWrong1);
                break;
        }
    }
    public void playCewekBuang()
    {
        int rand = (int)Random.Range(0, 0);
        switch (rand)
        {
            case 0:
                playSound(cewekBuang1);
                break;
        }
    }

    public void playPriaCorrect()
    {
        int rand = (int)Random.Range(0, 1.9f);
        switch (rand)
        {
            case 0:
                playSound(priaCorrect1);
                break;
            case 1:
                playSound(priaCorrect2);
                break;
        }
    }
    public void playPriaWrong()
    {
        int rand = (int)Random.Range(0, 0);
        switch (rand)
        {
            case 0:
                playSound(priaWrong1);
                break;
        }
    }
    public void playPriaBuang()
    {
        int rand = (int)Random.Range(0, 0);
        switch (rand)
        {
            case 0:
                playSound(priaBuang1);
                break;
        }
    }
    public void playOmWrong()
    {
        int rand = (int)Random.Range(0, 0);
        switch (rand)
        {
            case 0:
                playSound(omWrong1);
                break;
        }
    }
    public void playOmBuang()
    {
        int rand = (int)Random.Range(0, 0);
        switch (rand)
        {
            case 0:
                playSound(omBuang1);
                break;
        }
    }
    public void playTanteWrong()
    {
        int rand = (int)Random.Range(0, 0);
        switch (rand)
        {
            case 0:
                playSound(tanteWrong1);
                break;
        }
    }
    public void playTanteBuang()
    {
        int rand = (int)Random.Range(0, 0);
        switch (rand)
        {
            case 0:
                playSound(tanteBuang1);
                break;
        }
    }

    public void playQuake()
    {
        quakeSource.Play();
    }
    public void stopQuake()
    {
        quakeSource.Stop();
    }
}
