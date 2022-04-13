using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EMusicName
{
    BGM_TITLE,
    BGM_INGAME,
    SFX_CLICK,
    SFX_EXPLOSION,
    SFX_SHOT,
    SFX_ITEM,
}

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource audioSource;

    public AudioClip[] bgms;
    public AudioClip[] sfxs;

     void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(SceneChangeManager.Instance.SceneName() == "Title")
        {
            BgmPlay(EMusicName.BGM_TITLE);
        }
        else if(SceneChangeManager.Instance.SceneName() == "Ingame")
        {
            BgmPlay(EMusicName.BGM_INGAME);
        }
    }

    public void BgmPlay(EMusicName musicName)
    {
        audioSource.clip = GetClip(musicName);
        audioSource.loop = true;
        audioSource.Play();
    }
    public void SfxPlay(EMusicName musicName)
    {
        audioSource.clip = GetClip(musicName);
        audioSource.loop = false;
        audioSource.Play();
    }

    public AudioClip GetClip(EMusicName musicName)
    {
        AudioClip clip = null;
        switch(musicName)
        {
            case EMusicName.BGM_TITLE:
                clip = bgms[0];
                break;
            case EMusicName.BGM_INGAME:
                clip = bgms[1];
                break;
            case EMusicName.SFX_CLICK:
                clip = sfxs[0];
                break;
            case EMusicName.SFX_EXPLOSION:
                clip = sfxs[1];
                break;
            case EMusicName.SFX_SHOT:
                clip = sfxs[2];
                break;
            case EMusicName.SFX_ITEM:
                clip = sfxs[3];
                break;
        }
        return clip;
    }
}
