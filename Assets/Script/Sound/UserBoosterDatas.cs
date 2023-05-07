using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// An enum to define all of "Currency" in our game
/// </summary>
public enum BoosterType
{
    NONE = -1, //This type to determine error
    COIN = 0,
    GEM = 1,
}

/// <summary>
/// A class to contain a data of currency
/// </summary>
[System.Serializable]
public class BoosterDataCommodity
{
    public BoosterType _type;
    public long _value;

    public BoosterDataCommodity()
    {

    }
    public BoosterDataCommodity(BoosterType type, long value)
    {
        this._type = type;
        this._value = value;
    }
    public void AddValue(long v)
    {
        this._value += v;
    }
    public void SubtractValue(long v)
    {
        this._value = (long)Mathf.Clamp(this._value - v, 0, _value);
    }
    public void SetValue(long v)
    {
        this._value = v;
    }
}

/// <summary>
/// A class to save, manage user currency data
/// </summary>
[System.Serializable] 
public class UserBoosterDatas
{
    public const long STARTER_COIN = 1000;
    public const long STARTER_GEM = 0;

    public List<BoosterDataCommodity> _userBoosterData;
    public Dictionary<BoosterType, BoosterDataCommodity> _dictionaryUserBooster;

    //public static UserBoosterDatas Instance => GameDataManager.Instance.UserData?._boosterData;
    public void NewUser()
    {
        _userBoosterData = new List<BoosterDataCommodity>();
        _userBoosterData.Add(new BoosterDataCommodity(type: BoosterType.COIN, value: STARTER_COIN));
        _userBoosterData.Add(new BoosterDataCommodity(type: BoosterType.GEM, value: STARTER_GEM));
    }

    /// <summary>
    /// Xử lý khi user vừa mở app
    /// </summary>
    public void OpenApp()
    {
        SetUpDictionary();
    }
    /// <summary>
    /// Khởi tạo và đưa data đang có vào trong dictionary để dễ dàng truy cập
    /// </summary>
    private void SetUpDictionary()
    {
        this._dictionaryUserBooster = new Dictionary<BoosterType, BoosterDataCommodity>();
        foreach (BoosterDataCommodity item in this._userBoosterData)
        {
            if (!_dictionaryUserBooster.ContainsKey(item._type))
                _dictionaryUserBooster.Add(item._type, item);
        }
    }

    public void AddNewBooster(BoosterType type, long value)
    {
        if (this._userBoosterData == null)
            NewUser();

        if (this._dictionaryUserBooster == null)
            SetUpDictionary();

        if (!this._dictionaryUserBooster.ContainsKey(type))
            _dictionaryUserBooster.Add(type, new BoosterDataCommodity(type, value));
        else
            Debug.LogError($"EXISTED BOOSTER {type}");
    }
    public void AddValueBooster(BoosterType type, long value)
    {
        if (this._userBoosterData == null)
            NewUser();

        if (this._dictionaryUserBooster == null)
            SetUpDictionary();

        if (this._dictionaryUserBooster.TryGetValue(type, out BoosterDataCommodity item))
            item.AddValue(value);
        else
            Debug.LogError($"NOT EXISTED BOOSTER {type}");
    }
    public void SubtractValueBooster(BoosterType type, long value)
    {
        if (this._userBoosterData == null)
            NewUser();

        if (this._dictionaryUserBooster == null)
            SetUpDictionary();

        if (this._dictionaryUserBooster.TryGetValue(type, out BoosterDataCommodity item))
            item.SubtractValue(value);
        else
            Debug.LogError($"NOT EXISTED BOOSTER {type}");
    }
    public void SetValueBooster(BoosterType type, long value)
    {
        if (this._userBoosterData == null)
            NewUser();

        if (this._dictionaryUserBooster == null)
            SetUpDictionary();

        if (this._dictionaryUserBooster.TryGetValue(type, out BoosterDataCommodity item))
            item.SetValue(value);
        else
            Debug.LogError($"NOT EXISTED BOOSTER {type}");
    }
}
