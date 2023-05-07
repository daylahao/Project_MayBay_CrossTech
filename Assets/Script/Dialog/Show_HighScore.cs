using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_HighScore : BaseDialog
{
    public void OpenDialog()
    {
        GameManager.Instance.OnShowDialog<HighScorePopup>("Dialog/Dialog_Form");
    }
    
}
