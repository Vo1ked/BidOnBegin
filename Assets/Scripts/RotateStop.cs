using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class RotateStop : MonoBehaviour
{
    [SerializeField]
    private RectTransform ContentList;

    public float MinValue;
    [Range(0, 10)]
    public float Speed;
    private float _componentHeght;

    public bool StartMetod, LerpMove;

    private int _intNumber;

    private Vector2 _lerpTo;

    private PlayerData _data;

    private ScrollRect _scrollVelocity;

    public string KeyData = "GameStorage";

    // Use this for initialization
    void Start()
    {
        _data = new PlayerData();
        _componentHeght = ContentList.transform.GetChild(0).GetComponent<LayoutElement>().preferredHeight;
        _scrollVelocity = GetComponent<ScrollRect>();
        _data.CountEnemy = 1;
        PlayerPrefs.SetString(KeyData, JsonUtility.ToJson(_data));
    }

    // Update is called once per frame
    void Update()
    {
        CheckNumber();
    }

    public void Stopping()
    {
        StartMetod = true;
    }

    public int GetCount
    {
        get { return _intNumber; }
    }
    private void CheckNumber()
    {
        if (StartMetod)
        {
            if (Math.Abs(_scrollVelocity.velocity.y) <= MinValue)
            {
                _intNumber = (int)((ContentList.anchoredPosition.y + _componentHeght / 2)
                    / _componentHeght);
                _lerpTo = new Vector2(0, _componentHeght * _intNumber);

                if (!LerpMove)
                {
                    ContentList.anchoredPosition = _lerpTo;
                    _scrollVelocity.velocity.Set(0, 0);
                    _data.CountEnemy = _intNumber + 1;
                    PlayerPrefs.SetString(KeyData, JsonUtility.ToJson(_data));
                    StartMetod = false;
                }
                else
                {
                    ContentList.anchoredPosition =
                    Vector2.Lerp(ContentList.anchoredPosition, _lerpTo, Time.deltaTime * Speed);
                    if (Mathf.Abs(_lerpTo.y - ContentList.anchoredPosition.y) < 2f)
                    {
                        _data.CountEnemy = _intNumber + 1;
                        PlayerPrefs.SetString(KeyData, JsonUtility.ToJson(_data));
                        print(_data.CountEnemy);
                        StartMetod = false;

                    }
                }
            }
        }
    }

}
