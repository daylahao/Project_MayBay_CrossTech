using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Follow : Base_Bullet
{
    private float pos_x, pos_y;
    private void Start()
    {
       
    }
    private void Update()
    {
        Damage_Object = GameObject.FindGameObjectWithTag("Enermy");
        Vector_bullet();
    }
    public override void Vector_bullet()
    {
        pos_x = 0;
        if (Damage_Object != null)
        {
            pos_x = Damage_Object.transform.position.x - transform.position.x;
            if (pos_x > 0)
            {
                if (Mathf.Abs(pos_x) < 0.2f)
                {
                    pos_x = 0f;
                }
                else
                    pos_x = 1f;
            }
            else pos_x = -1f;
            pos_y = Damage_Object.transform.position.y - transform.position.y;
            if (pos_y > 0)
            {
                pos_y = 1f;
            }
            else pos_y = -1f;
            _Vector_Bullet = new Vector3(pos_x, pos_y);
        }
        base.Vector_bullet();
    }
}
