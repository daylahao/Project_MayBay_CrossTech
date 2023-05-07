using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Transform _popUpContainer;

    public void OnShowDialog<T>(string path, object data = null, UnityEngine.Events.UnityAction callbackCompleteShow = null) where T : BaseDialog
    {
        GameObject prefab = this.GetResourceFile<GameObject>(path);
        if (prefab != null)
        {
            T objectSpawned = (Instantiate(prefab, _popUpContainer)).GetComponent<T>();
            if (objectSpawned != null)
            {
                objectSpawned.OnShow(data, callbackCompleteShow);
            }
        }
    }
    /// <summary>
    /// Load một file từ folder Resource
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu hoặc 1 component</typeparam>
    /// <param name="path">Đường dẫn file, bỏ đuôi file và phần /Resource</param>
    /// <returns></returns>
    public T GetResourceFile<T>(string path) where T : Object
    {
        return Resources.Load<T>(path) as T;
    }

    /// <summary>
    /// Tạo điểm giả để đổ lên cho user, các bạn sẽ thay bằng Hàm lấy danh sách highscore được lưu dưới máy
    /// </summary>
    /// <returns></returns>
    public List<HighScoreData> GenerateFakeHighScore()
    {
        List<HighScoreData> _scores = new List<HighScoreData>();
        int amountGen = 100;
        for (int i = 0; i < amountGen; i++)
        {
            _scores.Add(new HighScoreData()
            {
                _score = Random.Range(minInclusive: 0, maxExclusive: 1000),
                _date = System.DateTime.Now
            });
        }

        return _scores;
    }
    public GameStatConfigs ConfigCharactor()
    {
        return GetResourceFile<GameStatConfigs>("Config/Gamestatconfig");
    }
    public SoundConfigs ConfigSound()
    {
        return GetResourceFile<SoundConfigs>("Config/SoundConfigs");
    }
}

public class HighScoreData
{
    public int _score;
    public System.DateTime _date;
}
