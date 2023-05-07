using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Userdata
{
    public List<int> high_score;
    public string user_name="H";
    public int id_plane;
    public int Amount_Bullet_A;
    public int Amount_Bullet_B;
    public static Userdata Instance => GameDataManager.Instance.data;
}

