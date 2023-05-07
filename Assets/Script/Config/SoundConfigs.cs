using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Games/Sounds")]
public class SoundConfigs : ScriptableObject
{
    public List<AudioClip> sounds;
    private static SoundConfigs _isntance;
    public static SoundConfigs Instance
    {
        get
        {
            if (_isntance == null)
            {
                _isntance = GameManager.Instance.GetResourceFile<SoundConfigs>("Config/SoundConfigs"); 
            }
            return _isntance;
        }

    }
    private Dictionary<string, AudioClip> temps;

    public AudioClip GetAudioByName(string key)
    {
        this.temps ??= new Dictionary<string, AudioClip>();
        AudioClip clip = null;

        if (this.temps.TryGetValue(key, out AudioClip clipFromDic))
            return clipFromDic;
        else
        {
            clip = this.sounds.Find(x => x.name.Equals(key));
            if (clip != null)
            {
                this.temps.Add(key, clip);
                return clip;
            }
        }

        Debug.LogError("CLIP NULL: " + key);
        return clip;
    }
}
