using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class TestTweenImage : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float timeAnimation;
    [ContextMenu("TestTween")]
    public void Editor_MoveByTween()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.DOFade(1f, 10f)
            .OnStart(()=> { canvasGroup.alpha = 0f; })
            .OnComplete(()=> Debug.Log("Xong"));
        //this.transform.DOLocalMoveY(endValue: Random.Range(-400, 400),duration: timeAnimation)
        //    .OnComplete(
        //    () =>
        //    {
        //        //debug
        //        //a+b = c;
        //    }
        //    )
        //    .OnStart(()=> { 

        //    })
        //    .SetDelay(5f)
        //    .SetLoops(1)
        //    .SetId("ThisMoveToY");

        //DOTween.Kill("ThisMoveToY");

        //GameObject A, B, C;

        //        Sequence seq = DOTween.Sequence();
        //        seq.OnStart(() => { }
        //)
        //        seq.Join(A.transform.DOLocalMoveY(100, 0.5f));
        //        seq.Join(B.transform.DOLocalMoveY(100, 0.5f));

        //        seq.Append(C.transform.DOLocalMoveY(-100, 0.5f));
        //        seq.AppendInterval(5f);
        //        seq.Join(A.transform.DOLocalMoveY(C.transform.position.y, 0.5f));
        //        seq.Append(B.transform.DOLocalMoveY(C.transform.position.y, 0.5f));

        //        seq.AppendCallback(() => {
        //            Debug.Log("Xong phan nửa gòi");
        //        });
        //        seq.Append(B.transform.DOLocalMoveY(C.transform.position.y, 0.5f));
        //        seq.Append(B.transform.DOLocalMoveY(C.transform.position.y, 0.5f));


        //        seq.OnComplete(() =>
        //        {

        //        });


    }
    //Sequence seq = DOTween.Sequence();
    //seq.Join(this.transform.DOLocalMoveY(100, 0.5f));
    //seq.Append(this.transform.DOLocalMoveY(-100, 0.5f));
    //seq.AppendInterval(5f);
    //seq.AppendCallback(()=> { });
    private void Notify(bool isON) { }
}
