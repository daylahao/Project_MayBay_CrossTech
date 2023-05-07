using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Normal : Base_Bullet
{
    private SoundConfigs SoundConfig;
    private void Start()
    {
        SoundConfig = GameManager.Instance.ConfigSound();
        SoundManager.Instance.PlayFx(SoundConfig.sounds[0].name);
    }
    private void Update()
    {
        Vector_bullet();
    }
    public override void Vector_bullet()
    {
        base.Vector_bullet();
    }
}