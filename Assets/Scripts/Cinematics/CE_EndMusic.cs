using UnityEngine;

public class CE_EndMusic : CinematicElement
{
    public AudioManager theAudio;
    public bool isEnded;
    public override void PostStartProcess()
    {
        theAudio.EndMusic();
        isEnded = true;
    }

    public override bool IsEnded()
    {
        return isEnded;
    }
}
