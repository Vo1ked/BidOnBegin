using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerData
{
    private PlayerData _data;
    public int CountEnemy;
    [SerializeField]
    public List<string> EnemyNames;
    [SerializeField]
    public List<string> PlayerName;
    [SerializeField]
    public List<int> PlayerScore;
    [SerializeField]
    public List<int> PlayerLvL;
    public int CurentPlayer;
    public bool ExsistPlayer;

    //public PlayerInfo AboutPlayer
    //{
    //    get
    //    {
    //        _data = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("GameStorage"));
    //        if (_data.PlayerName == null)
    //            return null;
    //        _data.AboutPlayer = new PlayerInfo(_data.PlayerName[_data.CurentPlayer],
    //        _data.PlayerLvL[_data.CurentPlayer], _data.PlayerScore[_data.CurentPlayer]);
    //        return _data.AboutPlayer;
    //    }
    //    set
    //    {
    //        var changePlayerInfo = value;
    //        _data = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("GameStorage"));
    //        if (_data.PlayerName.Count > 0)
    //        {
    //            _data.PlayerName[_data.CurentPlayer] = changePlayerInfo.PlayerName;
    //            _data.PlayerLvL[_data.CurentPlayer] = changePlayerInfo.PlayerLvl;
    //            _data.PlayerScore[_data.CurentPlayer] = changePlayerInfo.PlayerScore;
    //            PlayerPrefs.SetString("GameStorage", JsonUtility.ToJson(_data));
    //        }
    //    }
    //}

    public void NewPlayer(string newPlayerName)
    {
        _data = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("GameStorage"));
        if (_data == null)
        {
            _data = new PlayerData
            {
                PlayerName = new List<string>(),
                PlayerLvL = new List<int>(),
                PlayerScore = new List<int>()
            };
            _data.PlayerName.Add(newPlayerName);

        }
        else
            _data.PlayerName.Add(newPlayerName);
        _data.PlayerLvL.Add(1);
        _data.PlayerScore.Add(0);
        _data.CurentPlayer = _data.PlayerName.Count-1;
        Debug.Log("newPlayer");
        PlayerPrefs.SetString("GameStorage", JsonUtility.ToJson(_data));
      //  _data.AboutPlayer = new PlayerInfo(newPlayerName, 1, 0);
    }
}
