using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public float MovmentSpeed = 0.1f;

    public JoystickMoving JoystickLeft,JoystickRight;
    [SerializeField]
    private CharacterController _charterMove;
    // Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	    _charterMove.Move(new Vector3(-JoystickLeft.JosticValue.x, 0,
            -JoystickLeft.JosticValue.y ) * MovmentSpeed);
        transform.rotation= new Quaternion(JoystickRight.JosticValue.x,JoystickRight.JosticValue.y,0,0);
	}
}
