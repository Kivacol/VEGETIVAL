using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioCtrl : MonoBehaviour
{
    static AudioCtrl current;

    [Header("環境聲音")]
    public AudioClip musicClips;

    [Header("Player聲音")]
    public AudioClip idleClips;
    public AudioClip[] wlakStepClips;
    public AudioClip hurtClips;
    public AudioClip deadClips;
    public AudioClip fireClips;

    AudioSource musicSource;
    AudioSource playerSource;



    private void Awake()
    {
        current = this;

        //DontDestroyOnLoad(gameObject);

        musicSource = gameObject.AddComponent<AudioSource>();
        playerSource = gameObject.AddComponent<AudioSource>();

        StartLevelAudio();
    }

    void StartLevelAudio()
    {
        current.musicSource.clip = current.musicClips;
        current.musicSource.volume = 0.3f;
        current.musicSource.loop = true;
        current.musicSource.Play();
    }

    public static void PlayFootstepAudio()
    {
        int index = Random.Range(0, current.wlakStepClips.Length);

        current.playerSource.clip = current.wlakStepClips[index];
        current.playerSource.volume = 0.05f;
        current.playerSource.loop=true;
        current.playerSource.Play();

    }

    public static void StopFootstepAudio()
    {
       
        current.playerSource.Stop();
        current.playerSource.loop = false;

    }
}
