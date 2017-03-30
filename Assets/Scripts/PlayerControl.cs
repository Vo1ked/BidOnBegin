using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public float MovmentSpeed = 0.1f;

    public JoystickMoving Joystick;
    [SerializeField]
    private CharacterController _charterMove;
    // Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	    _charterMove.Move(new Vector3(Joystick.JoystickCurentPos.x, 0, Joystick.JoystickCurentPos.y ) * MovmentSpeed);
	}
}
