using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_Dialog : BaseDialog
{
    public GameObject prefab_form;
    public override void OnHide()
    {
        base.OnHide();
        if(prefab_form != null)
        {
            prefab_form.SetActive(false);
        }
    }
}
