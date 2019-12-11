using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public AudioClip explosionAudio;
    public AudioClip shotAudio;
    public AudioClip alarmAudio;
    //public AudioClip BGMAudio;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (SoundManager)FindObjectOfType(typeof(SoundManager));
                if (instance == null)
                {
                    Debug.LogError("SoundManager Instance Error");
                }
            }
            return instance;
        }
    }

    public void PlayExplosionAudio()
    {
        GetComponent<AudioSource>().PlayOneShot(explosionAudio);
    }

    public void PlayShootAudio()
    {
        GetComponent<AudioSource>().PlayOneShot(shotAudio);
    }

    public void PlayAlarmAudio()
    {
        GetComponent<AudioSource>().PlayOneShot(alarmAudio);
    }
}