using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Manager : MonoSingleton<Bullet_Manager>
{
}
public class Base_Bullet : MonoBehaviour
{
    public Vector3 _Vector_Bullet;
    public float speed_bullet = 5;
    public GameObject Damage_Object;
    public virtual void Vector_bullet()
    {
        Vector3 _Vector_ = new Vector3(0, 1f, 0);
        if (_Vector_Bullet != Vector3.zero)
            _Vector_ = _Vector_Bullet;
        transform.position += _Vector_ * speed_bullet * Time.deltaTime;
        float rot = Mathf.Atan2(_Vector_.x, _Vector_.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -rot);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Damage_Object != null)
        {
            if (collision.gameObject.tag == Damage_Object.tag)
            {
                Destroy(this.gameObject);
            }
        }
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}