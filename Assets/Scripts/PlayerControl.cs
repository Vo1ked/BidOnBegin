using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public float MovmentSpeed = 0.1f;

    public JoystickMoving JoystickLeft,JoystickRight;
    [SerializeField]
    private CharacterController _charterMove;

    private Transform _playerPos, CameraPointPos;

    public float  MinAngle,MaxAngle;

    private Vector3 _direction, _angleFixRotationX, _angleFixRotationY;

    // Use this for initialization
	void Start ()
	{
	    CameraPointPos = this.GetComponent<Transform>().GetChild(0);
	}
	
	// Update is called once per frame
	void Update ()
	{
   
	    CharterMove();
        CameraPointRotationX();
        CameraPointRotationY();
	}

    private void CharterMove()
    {
        _charterMove.Move(new Vector3(JoystickLeft.JosticValue.x, 0,
       JoystickLeft.JosticValue.y) * MovmentSpeed);
    }

    public void CameraPointRotationX()
    {

        _angleFixRotationX = new Vector3(Mathf.Clamp(-JoystickRight.JosticValue.y + 
            CameraPointPos.rotation.eulerAngles.x,MinAngle,MaxAngle), CameraPointPos.rotation.eulerAngles.y, 0);
        CameraPointPos.rotation = Quaternion.Euler(_angleFixRotationX);
    }

    public void CameraPointRotationY()
    {

        _angleFixRotationY = new Vector3(0, JoystickRight.JosticValue.x + 
            transform.rotation.eulerAngles.y, 0);
        transform.rotation = Quaternion.Euler(_angleFixRotationY);
    }


}
