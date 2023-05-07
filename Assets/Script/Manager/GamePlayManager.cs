using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager :MonoSingleton<GamePlayManager>
{
    public GameObject Plane_id;
    public int amount_Bullet_A, amount_Bullet_B;
    public int Score_player;
    public void StartGame(Userdata GameData)
    {
         
        GameUIManager.Instance.Update_Highscore_text();
        Score_player = 0;
        Instantiate(Plane_id, new Vector3(0, 0, 0), Quaternion.identity);
        amount_Bullet_A = GameData.Amount_Bullet_A;
    }
    public void ShootA()
    {
        amount_Bullet_A--;
    }
    public void ShootB()
    {
        amount_Bullet_B--;
    }
    public float SpeedDefault()
    {
        return GameStatConfigs.Instance.PlayerSpeed;
    }
    public void PlayerDeath()
    {
        GameManager.Instance.OnShowDialog<Menu_Dialog>("Dialog/Container_Again");
        EnermyManager.Instance.PauseGane();
    }
}
