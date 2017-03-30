using UnityEngine;
using System.Collections;

public class CameraFolowing : MonoBehaviour
{
    [SerializeField] private Transform Player;
    private Transform _playerLook;

    public float _lerpSpeed;


	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position,Player.GetChild(0).position,Time.deltaTime * _lerpSpeed);
        transform.LookAt(Player);
	}
}
