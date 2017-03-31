using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public float MovmentSpeed = 0.1f;

    public JoystickMoving JoystickLeft,JoystickRight;
    [SerializeField]
    private CharacterController _charterMove;

    private Transform _playerPos, CameraPointPos;





    // Use this for initialization
	void Start ()
	{
	    CameraPointPos = this.GetComponent<Transform>().GetChild(0);
	}
	
	// Update is called once per frame
	void Update ()
	{
   
	    CharterMove();
	}

    private void CharterMove()
    {
        _charterMove.Move(new Vector3(JoystickLeft.JosticValue.x, 0,
       JoystickLeft.JosticValue.y) * MovmentSpeed);
    }



}
