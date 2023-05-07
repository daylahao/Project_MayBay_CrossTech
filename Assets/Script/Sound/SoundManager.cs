using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    public SoundBase _fxSoundBase;
    public SoundBase _fxMusicBGBase;

    public bool isOnMusic = true;
    public bool isOnFx = true;

    public UnityEngine.Events.UnityAction<bool> _cbOnChangeOnFx;
    public UnityEngine.Events.UnityAction<bool> _cbOnChangeOnBGMusic;

    #region Fx

    public void PlayFx(string key)
    {
        Play(key, _fxSoundBase);
    }
    public void PlayLoopFx(string key)
    {
        PlayLoop(key, _fxSoundBase);
    }
    public void StopFx()
    {
        Stop( _fxSoundBase);
    }
    public void AssignCallbackFx(UnityEngine.Events.UnityAction<bool> cb)
    {
        _cbOnChangeOnFx -= cb;
        _cbOnChangeOnFx += cb;
    }
    public void UnAssignCallbackFx(UnityEngine.Events.UnityAction<bool> cb)
    {
        _cbOnChangeOnFx -= cb;
    }
    public void InvokeCallbackFx(bool isOn)
    {
        this.isOnFx = isOn;
        _cbOnChangeOnFx?.Invoke(isOn);
    }
    #endregion Fx

    #region Music
    public void PlayBGMusic(string key)
    {
        Play(key, _fxMusicBGBase);
    }
    public void PlayLoopBGMusic(string key)
    {
        PlayLoop(key, _fxMusicBGBase);
    }
    public void StopBGMusic()
    {
        Stop(_fxMusicBGBase);
    }
    public void AssignCallbackMusicBG(UnityEngine.Events.UnityAction<bool> cb)
    {
        _cbOnChangeOnBGMusic -= cb;
        _cbOnChangeOnBGMusic += cb;
    }
    public void UnAssignCallbackMusicBG(UnityEngine.Events.UnityAction<bool> cb)
    {
        _cbOnChangeOnBGMusic -= cb;
    }
    public void InvokeCallbackMusicBG(bool isOn)
    {
        this.isOnMusic = isOn;
        _cbOnChangeOnBGMusic?.Invoke(isOn);
    }
    #endregion Music

    #region Common Code
    private void Play(string key, SoundBase b)
    {
        if (b != null)
            b.Play(key);
    }
    private void PlayLoop(string key, SoundBase b)
    {
        if (b != null)
            b.PlayLoop(key);
    }
    private void Stop(SoundBase b)
    {
        if (b != null)
            b.StopSound();
    }

    #endregion Common Code


}
