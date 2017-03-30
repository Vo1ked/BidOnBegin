using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesChange : MonoBehaviour
{
    private PlayerData _data;

    [SerializeField] private GameObject _imputTextFieald, _errormessage;

    private char[] _delimiter;

    [SerializeField] private Text _TextForChange;


	// Use this for initialization
	void Start () {
        _data = new PlayerData();
	    _delimiter = new char[] {'|', ' ', '.',','};

    }   

	
	// Update is called once per frame
	void Update ()
    { 

	}

    public void EnemyStringToList()
    {
        _data = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("EnemyNum"));
        _data.EnemyNames.Clear();
        _data.EnemyNames = _imputTextFieald.GetComponent<InputField>().text.Split(_delimiter).ToList();
        PlayerPrefs.SetString("EnemyNum",JsonUtility.ToJson(_data));
        print(JsonUtility.ToJson(_data));
    }


    public void SceneChengeOnClick()
    {
        int _diff;
        if (_data.EnemyNames == null)
        {
            _TextForChange.text = "not entered write enemy names";
            _errormessage.SetActive(true);
            return;
        }
        {
            
        }

        if (_data.EnemyNames.Count != _data.CountEnemy )
        {
            if (_data.EnemyNames.Count > _data.CountEnemy )
            {
                _diff = _data.EnemyNames.Count - _data.CountEnemy;
                _TextForChange.text = "more by  " + _diff + "  please Write less Enemy names";
            }
            if (_data.EnemyNames.Count < _data.CountEnemy )
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

