using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoSingleton<GameUIManager>
{
    public Image HP_Bar;
    public TextMeshProUGUI Text_Score;
    public TextMeshProUGUI Text_highscore;
    public void Update_Highscore_text()
    {
        GameDataManager.Instance.data.high_score.Sort();
        List<int> scores = GameDataManager.Instance.data.high_score;
        Text_highscore.text = scores[scores.Count - 1].ToString();
        Debug.Log(GameDataManager.Instance.data.high_score.ToString());
    }
    public void Update_HP_Bar()
    {
        HP_Bar.fillAmount -= 0.5f;
    }
    public void Reset_HP_Bar()
    {
        HP_Bar.fillAmount = 1f;
    }
    public void ClickShootBulletA()
    {
        if (GamePlayManager.Instance.amount_Bullet_A > 0)
        {
            GamePlayManager.Instance.ShootA();
        }
    }
    public void ClickShootBulletB()
    {
        if (GamePlayManager.Instance.amount_Bullet_A > 0)
        {
            GamePlayManager.Instance.ShootB();
        }
    }
    public void Update_score(GameObject Enermy_Object)
    {
            if(Enermy_Object.tag =="Enermy")
            {
            GamePlayManager.Instance.Score_player += 10;
            Text_Score.text = GamePlayManager.Instance.Score_player.ToString();    
            }
    }
    public void Reset_Score()
    {
        GamePlayManager.Instance.Score_player = 0;
        Text_Score.text = GamePlayManager.Instance.Score_player.ToString();
    }
}
