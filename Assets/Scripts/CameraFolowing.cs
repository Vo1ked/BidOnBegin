using UnityEngine;
using System.Collections;

public class CameraFolowing : MonoBehaviour
{
    [SerializeField] private Transform Player,CameraPos;
    private Transform _cameraPointRotate;

    public JoystickMoving JoystickRight;

    public float MinAngle, MaxAngle;

    public float LerpSpeed;

    private Vector3 _angleFixRotationX, _angleFixRotationY;


    // Use this for initialization
    void Start ()
    {
        _cameraPointRotate = Player.GetChild(0);
    }
	
	// Update is called once per frame
	void Update ()
	{
	    CameraMoveToPosition();
        transform.LookAt(Player);
        CameraAxisXRotation();
        CameraAxisYRotation();

	}

    public void CameraMoveToPosition()
    {
        transform.position = Vector3.Lerp(transform.position, CameraPos.position,Time.deltaTime * LerpSpeed);
    }

    public void CameraAxisXRotation()
    {

        _angleFixRotationX = new Vector3(Mathf.Clamp(-JoystickRight.JosticValue.y +
        _cameraPointRotate.rotation.eulerAngles.x, MinAngle, MaxAngle), _cameraPointRotate.rotation.eulerAngles.y, 0);
        _cameraPointRotate.rotation = Quaternion.Euler(_angleFixRotationX);
    }

    public void CameraAxisYRotation()
    {

        _angleFixRotationY = new Vector3(0, JoystickRight.JosticValue.x +
        Player.transform.rotation.eulerAngles.y, 0);
        Player.transform.rotation = Quaternion.Euler(_angleFixRotationY);
    }

}
