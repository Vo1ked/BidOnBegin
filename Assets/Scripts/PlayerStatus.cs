using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    private PlayerData _data;
    public Text PlayerName;
    public Text LVL;
    public Text Score;


    // Use this for initialization
    void Start ()
	{
	    _data = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("GameStorage"));
        PlayerName.text = _data.PlayerName[_data.CurentPlayer];
	    LVL.text =" " + _data.PlayerLvL[_data.CurentPlayer];
	    Score.text = " " + _data.PlayerScore[_data.CurentPlayer];

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
