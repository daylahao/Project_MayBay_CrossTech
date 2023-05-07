using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName="Games/GameStatconfigs",fileName ="Gamestatconfig")]
public class GameStatConfigs : ScriptableObject
{
    #region Singleton
    private static GameStatConfigs _instance;
    public static GameStatConfigs Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameManager.Instance.GetResourceFile<GameStatConfigs>("Config/GameStatConfigs");
            }
            return _instance;
        }
    }
    public int PlayerDefaultCoin;
    public float PlayerSpeed;
    public List<PlayerId> ListPlane;
    [System.Serializable]
    public class PlayerId
    {
        [SerializeField]
        public int PreFab_ID;
        public int PlaneHp;
    }
    public List<EnermyId> ListEnermy;
    [System.Serializable]
    public class EnermyId
    {
        [SerializeField]
        public int PreFab_ID;
        public float EnermySpeed;
        public float EnermyHp;
        public int EnermyDefaultCoin;
        public float EnermyDamage;
    }
    #endregion
}


