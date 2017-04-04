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

	// Use this for initialization
	void Start () {
	    _player = GameObject.FindGameObjectWithTag("Player");
	    _camera = GameObject.FindWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        Canvas.transform.LookAt(_camera.transform.position);
	    if (SlideArea.value <1)
	    {
	        _player.GetComponent<PlayerControl>().EnemyTarget = null;
            Destroy(gameObject);

        }
    }

    public void EnemyHit(float damage)
    {
        SlideArea.value -= damage;
    }
}
