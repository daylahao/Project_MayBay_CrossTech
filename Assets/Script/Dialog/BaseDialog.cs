using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class BaseDialog : MonoBehaviour
{
    public Animator _animator;

    protected object _data;
    protected UnityAction callbackShow;

    public const string ANIMATOR_SHOW = "Show_Dialog";
    public const string ANIMATOR_HIDE = "Close_Dialog";

#if UNITY_EDITOR
    protected virtual void OnValidate()
    {
        this._animator = this.GetComponent<Animator>();
    }
#endif


    public virtual void OnShow(object data = null, UnityEngine.Events.UnityAction callback = null)
    {
        this.gameObject.SetActive(true);
        this._data = data;
        this.callbackShow = callback;

        _animator.Play(ANIMATOR_SHOW);
    }
    public virtual void OnCompleteShow()
    {
        if (this.callbackShow != null)
        {
            var bk = this.callbackShow;
            this.callbackShow = null;
            bk.Invoke();
        }

        Debug.Log("Complete Show");
    }

    public virtual void ClickCloseDialog()
    {

        OnHide();
    }
    public virtual void OnHide()
    {
        
        _animator.Play(ANIMATOR_HIDE);
    }
    protected virtual void OnCompleteHide()
    {
        this.gameObject.SetActive(false);
       
    }
}
