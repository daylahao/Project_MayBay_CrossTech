using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;

public class Menu_Dialog : BaseDialog
{
    public void ClickNewGame()
    {
        ClickCloseDialog();
        GameDataManager.Instance.StartGame();
    }
    public void ClickPlayAgain()
    {
        this.DOfade
        ClickCloseDialog();
        GameUIManager.Instance.Reset_HP_Bar();
        GameUIManager.Instance.Reset_Score();
        GameDataManager.Instance.StartGame();
    }
}
