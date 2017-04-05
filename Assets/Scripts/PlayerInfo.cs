using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public string PlayerName;
    public int PlayerLvl;
    public int PlayerScore;

    public PlayerInfo(string Name, int LVl, int Score)
    {
        PlayerName = Name;
        PlayerLvl = LVl;
        PlayerScore = Score;
    }
}
