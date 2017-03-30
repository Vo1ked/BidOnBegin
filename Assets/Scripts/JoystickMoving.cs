using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class JoystickMoving : MonoBehaviour
{
    private float _maxPos = 80,_onePercent;

    public Vector2  JoystickZeroPos = Vector2.zero, JoystickCurentPos = Vector2.zero;

    public RectTransform JojstickCenter, JojstickCurent;


	// Use this for initialization
	void Start ()
	{
	    _onePercent = 1f/_maxPos;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void JosticMove(BaseEventData eventData)
    {
        JojstickCurent.transform.position =(eventData as PointerEventData).position;
        float _dist = Vector2.Distance(JojstickCenter.transform.position, JojstickCurent.transform.position);
        Vector3 _direction = JojstickCurent.transform.position - JojstickCenter.transform.position;
        if (_dist >= _maxPos)
        {
            JojstickCurent.transform.position = JojstickCenter.transform.position + _direction.normalized * _maxPos;
        }
        JoystickCurentPos = new Vector2(JojstickCurent.anchoredPosition.x*_onePercent, JojstickCurent.anchoredPosition.y * _onePercent);

    }

    public Vector2 JosticValue
    {
        get { return JoystickCurentPos; }
    }
    //public void JosticMove()
    //{
    //    JojstickCurent.anchoredPosition = new Vector2(Input.mousePosition.x - JojstickCenter.anchoredPosition.x ,
    //        Input.mousePosition.y - JojstickCenter.anchoredPosition.y );

    //    Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)+ "Camera");
    //    float _dist = Vector2.Distance(JojstickCenter.anchoredPosition, JojstickCurent.anchoredPosition);

    //    Vector2 _direction = JojstickCurent.anchoredPosition - JojstickCenter.anchoredPosition;
    //   // Debug.Log(JojstickCenter.anchoredPosition);
    //    Debug.Log(Input.mousePosition + "world");

    //    if (_dist >= _maxPos)
    //    {
    //        JojstickCurent.anchoredPosition = JojstickCenter.anchoredPosition + _direction.normalized * _maxPos;
    //    }
    //    //GetComponent<RectTransform>().anchoredPosition = new Vector2(Mathf.Clamp(Input.mousePosition.x - 128, _minPos, _maxPos), Mathf.Clamp(Input.mousePosition.y - 128, _minPos, _maxPos));
    //}
    public void JosticStartPos()
    {
        GetComponent<RectTransform>().anchoredPosition = JoystickZeroPos;
        JoystickCurentPos = Vector2.zero;
    }
}
