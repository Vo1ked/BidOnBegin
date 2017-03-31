﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class JoystickMoving : MonoBehaviour
{
    private float _maxPos,_onePercent;

    private Vector2  _joystickZeroPos = Vector2.zero, _joystickSendPos = Vector2.zero;

    private RectTransform _joystickCenter, _joystickCurent, Point;


    // Use this for initialization
    void Start ()
    {
        _joystickCurent = GetComponent<Transform>().GetChild(0).GetComponent<RectTransform>();
        _joystickCenter = GetComponent<RectTransform>();
        Point = GetComponent<Transform>().GetChild(1).GetComponent<RectTransform>();
        _maxPos = Vector3.Distance(_joystickCenter.GetComponent<Transform>().position,
	    Point.GetComponent<Transform>().position);
	    _onePercent = 1f/_maxPos;
	}
	
	// Update is called once per frame
	void Update () {

	}


        public void JoystickPointerMove(BaseEventData eventData)
    {
        _joystickCurent.transform.position =(eventData as PointerEventData).position;
        float dist = Vector2.Distance(_joystickCenter.transform.position, _joystickCurent.transform.position);
        Vector3 direction = _joystickCurent.transform.position - _joystickCenter.transform.position;
        if (dist >= _maxPos)
        {
            _joystickCurent.transform.position = _joystickCenter.transform.position + direction.normalized * _maxPos;
        }
        _joystickSendPos = new Vector2(_joystickCurent.anchoredPosition.x*_onePercent, _joystickCurent.anchoredPosition.y * _onePercent);

    }

    public void JoystickMove()
    {
        
    }


    public Vector2 JosticValue
    {
        get { return _joystickSendPos; }
    }
    public void JosticStartPos()
    {
        _joystickCurent.anchoredPosition = _joystickZeroPos;
        _joystickSendPos = Vector2.zero;
    }
}
