﻿using UnityEngine;
using System.Collections;

public class CameraFolowing : MonoBehaviour
{
    [SerializeField] private Transform Player;

    private Vector3 _playerPos,_rotate;
    [Range(-1,-50)]
    public float CameraRange;

	// Use this for initialization
	void Start ()
	{
	    _rotate = transform.position- Player.position;

	}
	
	// Update is called once per frame
	void Update () {
        //_playerPos =new Vector3(Player.position.x,Player.position.y +3, Player.position.z - CameraRange); 

        transform.LookAt(Player);
	    transform.position = _playerPos;

	}
}
