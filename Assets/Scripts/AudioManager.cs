using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public AudioSource CurrentMusic;
    public AudioSource NextMusic;
    public AudioSource CurrentSource;
    public AudioSource NextSource;
    public AudioClip Intro;
    public AudioClip TheLoop;
    public AudioClip Drop;
    private bool isChangedQueud;
    private AudioClip NextClip;
    private bool nextSongIsLooped;
    private float TimeBeforeEnd;
    private bool WaitTillEnding;
    void Start()
    {
        StartCoroutine(StartMusic());
    }

    void Update()
    {
        if (isChangedQueud)
        {
            isChangedQueud = false;
            StartCoroutine(ChangeTheMusic(NextClip, nextSongIsLooped, WaitTillEnding));
        }
    }
    IEnumerator StartMusic()
    {
        double CurrentTime = AudioSettings.dspTime;

        CurrentMusic.clip = Intro;
        CurrentMusic.PlayScheduled(CurrentTime + 0.1);

        NextMusic.clip = TheLoop;
        NextMusic.loop = true;
        NextMusic.PlayScheduled(CurrentTime + 0.1 + Intro.length);
        yield return null;
    }

    public void ChangeMusic(AudioClip myClip, bool looped, bool waitTillTheEnd)
    {
        isChangedQueud = true;
        NextClip = myClip;
        nextSongIsLooped = looped;
        WaitTillEnding = waitTillTheEnd;
        
    }

    IEnumerator ChangeTheMusic(AudioClip nextClip, bool looped, bool waitTillTheEnd)
    {
        double CurrentTime = AudioSettings.dspTime;
        if (CurrentMusic.isPlaying)
        {
            CurrentSource = CurrentMusic;
            NextMusic.clip = nextClip;
            NextSource = NextMusic;
        }
        else
        {
            CurrentSource = NextMusic;
            CurrentMusic.clip = nextClip;
            NextSource = CurrentMusic;

        }
        
        CurrentSource.loop = false;
        if (!waitTillTheEnd)
        {
            NextSource.loop = looped;
            NextSource.volume = 0f;
            NextSource.Play();
            while(CurrentSource.volume > 0.01f || NextSource.volume < 0.8f)
            {
                CurrentSource.volume = Mathf.Lerp(CurrentSource.volume, 0f, 0.2f);
                NextSource.volume = Mathf.Lerp(NextSource.volume, 0.8f, 0.2f);
                yield return null;
            }
            CurrentSource.volume = 0f;
            NextSource.volume = 0.8f;
            


            CurrentSource.Stop();
            yield break;
        }
        else
        {
            double currentTime = AudioSettings.dspTime;
            double timeRemaining = CurrentSource.clip.length - CurrentSource.time;
            double nextStartTime = currentTime + timeRemaining;
            NextSource.loop = looped;
            NextSource.PlayScheduled(nextStartTime);
            yield break;
        }


    }

    public void EndMusic()
    {
        StartCoroutine(EndLevel());
    }
    IEnumerator EndLevel()
    {
        if (CurrentMusic.isPlaying)
        {
            CurrentSource = CurrentMusic;
        }
        else
        {
            CurrentSource = NextMusic;

        }

        while(CurrentSource.volume > 0.01f)
        {
            CurrentSource.volume = Mathf.Lerp(CurrentSource.volume, 0f, 0.2f);
            yield return null;
        }
        CurrentSource.volume = 0f;
        yield break;

    }
}
