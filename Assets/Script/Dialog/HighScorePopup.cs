using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
public class HighScorePopup : BaseDialog
{
    public TextMeshProUGUI _prefabText;
    public Transform _tfPanelScore;
    public override void OnCompleteShow()
    {
        base.OnCompleteShow();

        List<HighScoreData> score = GameManager.Instance.GenerateFakeHighScore();

        score.Sort((x, y) => x._score.CompareTo(y._score));
        //score.OrderByDescending(x=>x._score);

        for (int i = 0; i < score.Count; i++)
        {
            TextMeshProUGUI s = Instantiate<TextMeshProUGUI>(_prefabText, this._tfPanelScore);
            s.gameObject.SetActive(true);
            s.SetText($"{score[i]._score} - {score[i]._date.ToShortDateString()}");
        }
    }
}
