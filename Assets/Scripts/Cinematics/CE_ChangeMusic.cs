using UnityEngine;
using System.Collections;

public class CE_ChangeMusic : CinematicElement
{
    public AudioManager Audio;
    public AudioClip myClip;
    public bool IsLooped;
    public bool WaitTillTheEnd;
    public bool isEnded;
    public override void PostStartProcess()
    {
        Audio = FindFirstObjectByType<AudioManager>();
        Audio.ChangeMusic(myClip, IsLooped, WaitTillTheEnd);
        isEnded = true;
    }

    public override bool IsEnded()
    {
        return isEnded;
    }

}
