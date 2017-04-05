using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Text TextArea;

    public Slider SlideArea;

    [SerializeField] public Canvas Canvas;

    private GameObject _player;
    private GameObject _camera;
    private PlayerStatus _changeScore;
    private PlayerData _data;

	// Use this for initialization
	void Start () {
	    _player = GameObject.FindGameObjectWithTag("Player");
	    _camera = GameObject.FindWithTag("MainCamera");
	    _changeScore = GameObject.FindGameObjectWithTag("PlayerStatus").GetComponent<PlayerStatus>();
	}
	
	// Update is called once per frame
	void Update () {
        Canvas.transform.LookAt(_camera.transform.position);
	    if (SlideArea.value <1)
	    {
	        _player.GetComponent<PlayerControl>().EnemyTarget = null;
	        _data = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("GameStorage"));
            Debug.Log(_data.PlayerScore[_data.CurentPlayer]);
	        _data.PlayerScore[_data.CurentPlayer]++;
	        string writeFile = JsonUtility.ToJson(_data);
            PlayerPrefs.SetString("GameStorage", writeFile);
            _changeScore.Score.text = " " + _data.PlayerScore[_data.CurentPlayer];
            Destroy(gameObject);

        }
    }

    public void EnemyHit(float damage)
    {
        SlideArea.value -= damage;
    }
}
