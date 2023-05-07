using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User_Plane :MonoBehaviour
{
    private float Speed;
    private GameStatConfigs PlayerStat;
    public bool IsStartGame;
    private float Timer,Speed_Shoot = 0.5f;
    public GameObject Bullet;
    public GameObject Bullet_A;
    public GameObject Bullet_B;
    public GameObject Gun_Plane;
    public bool Fire;
    // Start is called before the first frame update
    void Start()
    {
        IsStartGame = true;
        Timer = Time.time;
        PlayerStat  = GameManager.Instance.ConfigCharactor();
        Speed = PlayerStat.PlayerSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        if(IsStartGame)
        {
            float Vector_X = Input.GetAxis("Horizontal");
            float Vector_Y = Input.GetAxis("Vertical");
            transform.position += new Vector3(Vector_X, Vector_Y, 0) * Speed * Time.deltaTime;
            Timer += Time.deltaTime;
            if(Timer > Speed_Shoot)
            {
                Shoot(Bullet);
                Timer = 0;
            }
            Shoot_AB();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameUIManager.Instance.Update_HP_Bar();
        if (GameUIManager.Instance.HP_Bar.fillAmount <= 0)
        {
            GameDataManager.Instance.savedata();
            GamePlayManager.Instance.PlayerDeath();
            Destroy(this.gameObject);
        }
    }
    public void Shoot_AB()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            GameUIManager.Instance.ClickShootBulletA();
            Shoot(Bullet_A);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameUIManager.Instance.ClickShootBulletB();
            Shoot(Bullet_B);
        }
    }
    public void Shoot(GameObject Bullet_Prefab)
    {
        if (Fire)
        {
            GameObject Bullet = Instantiate(Bullet_Prefab, new Vector3(Gun_Plane.transform.position.x, Gun_Plane.transform.position.y + 1f, 0), Quaternion.identity);
        }
    }

}
