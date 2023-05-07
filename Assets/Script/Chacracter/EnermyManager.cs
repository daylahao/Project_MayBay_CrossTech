using UnityEngine;

public class EnermyManager : MonoSingleton<EnermyManager>
{
    public GameObject Creep_Enermy;
    public GameObject Boss_Enermy;
    private bool IsStartGame;
    float Timer;
    public float speed_spawn = 1f;
    public void StartGame()
    {
        IsStartGame = true;
        Timer = Time.time;
    }
    public void PauseGane()
    {
        IsStartGame = false;
        Timer = 0;
    }
    public void Update()
    {
        if (IsStartGame)
        {
            float Seed_Y = Random.Range(5.07f, 7.21f);
            float Seed_X = Random.Range(-2.2f, 2.62f);
            Timer += Time.deltaTime;
            if (Timer > speed_spawn && GamePlayManager.Instance.Score_player % 10 > 5)
            {
                Instantiate(Boss_Enermy, new Vector3(Seed_X, Seed_Y, 0), Quaternion.identity);
                Timer = 0;
            }
            if (Timer > speed_spawn)
            {
                
                Instantiate(Creep_Enermy, new Vector3(Seed_X, Seed_Y, 0), Quaternion.identity);
                Timer = 0;
            }
        }
    }
}
public class Base_Enermy : MonoBehaviour
{
    public float speed = 5f;
    public float shoot_speed;
    public Vector3 vector_move = Vector3.zero;
    public virtual void Enermy_Rotation_Default()
    {
        transform.rotation = Quaternion.Euler(0, 0, 180f);
    }
    public virtual void Enermy_Move()
    {
        transform.position += new Vector3(0, -1f, 0) * speed * Time.deltaTime;
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameUIManager.Instance.Update_score(this.gameObject);
        Destroy(this.gameObject);
    }
}

