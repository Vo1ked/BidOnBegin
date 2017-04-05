using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesChange : MonoBehaviour
{
    private PlayerData _data;

    [SerializeField]
    private GameObject _errormessage;

    [SerializeField]
    private InputField _imputEnemyNamesField;
    [SerializeField]
    private InputField _inputPlayerNameField;

    private char[] _delimiter;

    [SerializeField]
    private Text _TextForChange;
    [SerializeField]
    private Text _TextForChangeHigter;

    private int _diff;

    private PlayerInfo _temp;

    private bool _playerExsist;


    // Use this for initialization
    void Start()
    {
        _data = new PlayerData();
        _delimiter = new char[] { '|', '.', ',' };


    }


    // Update is called once per frame
    void Update()
    {

    }
    public void SceneChengeOnClick()
    {
        _playerExsist = false;
        _data = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("GameStorage"));
        //if (_data.EnemyNames == null)
        //    _data.EnemyNames = new List<string>();
        _data.EnemyNames.Clear();
        _data.EnemyNames = _imputEnemyNamesField.GetComponent<InputField>().text.Split(_delimiter).ToList();
        PlayerPrefs.SetString("GameStorage", JsonUtility.ToJson(_data));
        _TextForChangeHigter.text = "Enemy Names is";
        if (string.IsNullOrEmpty(_data.EnemyNames[0]))
        {
            _TextForChange.text = "not entered write enemy names";
            _errormessage.SetActive(true);
            return;
        }
        if (string.IsNullOrEmpty(_inputPlayerNameField.text))
        {
            _TextForChangeHigter.text = "Player Names is";
            _TextForChange.text = "not entered write player name";
            _errormessage.SetActive(true);
            return;
        }
        for (int i = 0; i < _data.PlayerName.Count; i++)
        {
            if (_data.PlayerName[i] == _inputPlayerNameField.text)
            {
                _data.CurentPlayer = i;
                _playerExsist = true;

            }
        }
        if (!_playerExsist)
            _data.NewPlayer(_inputPlayerNameField.text);

        if (_data.EnemyNames.Count != _data.CountEnemy)
        {
            if (_data.EnemyNames.Count > _data.CountEnemy)
            {
                _diff = _data.EnemyNames.Count - _data.CountEnemy;
                _TextForChange.text = "more by  " + _diff + "  please Write less Enemy names";
            }
            if (_data.EnemyNames.Count < _data.CountEnemy)
            {
                _diff = _data.CountEnemy - _data.EnemyNames.Count;
                _TextForChange.text = "less by  " + _diff + "  please Write more Enemy names";
            }
            _errormessage.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("LVL1");
        }

    }
}
