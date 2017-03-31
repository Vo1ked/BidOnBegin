using UnityEngine;
using System.Collections;

public class CameraFolowing : MonoBehaviour
{
    [SerializeField] private Transform Player,CameraPos;
    private Transform _playerLook;

    public float LerpSpeed;


	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, CameraPos.position,Time.deltaTime * LerpSpeed);
        transform.LookAt(Player);
	}
}
