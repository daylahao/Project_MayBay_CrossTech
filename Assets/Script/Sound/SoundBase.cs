using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBase : MonoBehaviour
{
    public AudioSource _sourcePlaySound;

    public void Play(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            Debug.LogError("KEY NULL: " + key);
            return;
        }

        if (_sourcePlaySound != null)
        {
            _sourcePlaySound.clip = SoundConfigs.Instance.GetAudioByName(key); //LoaderUtility.Instance.GetAsset<AudioClip>(key);
            _sourcePlaySound.loop = false;
            _sourcePlaySound.mute = false;

            _sourcePlaySound.Play();
        }
    }
    public void PlayLoop(string key)
    {
        this.Play(key);
        _sourcePlaySound.loop = true;
    }
    public void StopSound()
    {
        if (this._sourcePlaySound == null)
        {
            return;
        }
        _sourcePlaySound.Stop();
    }
}
