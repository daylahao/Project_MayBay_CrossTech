using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Center : Base_Bullet
{
        public GameObject Bullet_child;
    public void Update()
    {
        Vector_bullet();
    }
    public override void Vector_bullet()
    {
        base.Vector_bullet();
        Debug.Log(transform.position.y);
        if (transform.position.y > 0)
        {
            Vector3 Pos_parent = transform.position;
            GameObject Bullet_1 = Instantiate(Bullet_child, new Vector3(Pos_parent.x, Pos_parent.y + 1f, 0), Quaternion.identity);
            Bullet_1.GetComponent<Bullet_Normal>()._Vector_Bullet = new Vector3(0, 1f, 0);
            Bullet_1.GetComponent<Bullet_Normal>().Damage_Object = GameObject.FindGameObjectWithTag("Enermy");
            GameObject Bullet_2 = Instantiate(Bullet_child, new Vector3(Pos_parent.x + 1f, Pos_parent.y, 0), Quaternion.identity);
            Bullet_2.GetComponent<Bullet_Normal>()._Vector_Bullet = new Vector3(1f, 1f, 0);
            Bullet_2.GetComponent<Bullet_Normal>().Damage_Object = GameObject.FindGameObjectWithTag("Enermy");
            GameObject Bullet_3 = Instantiate(Bullet_child, new Vector3(Pos_parent.x - 1f, Pos_parent.y, 0), Quaternion.identity);
            Bullet_3.GetComponent<Bullet_Normal>()._Vector_Bullet = new Vector3(-1f, 1f, 0);
            Bullet_3.GetComponent<Bullet_Normal>().Damage_Object = GameObject.FindGameObjectWithTag("Enermy");
            Destroy(this.gameObject);
        }
    }
}
