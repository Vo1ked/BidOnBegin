using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public float MovmentSpeed = 0.1f;
    private float _distance = 5000;


    public JoystickMoving JoystickLeft;
    [SerializeField] private CharacterController _charterMove;

    private Transform _playerPos;

    public GameObject Bullet;

    private Ray _direction;

    private RaycastHit hit;

    public Enemy EnemyTarget;




    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CharterMove();
        Debug.DrawLine(transform.position, transform.forward, Color.red);

    }

    private void CharterMove()
    {
        _charterMove.Move(new Vector3(JoystickLeft.JosticValue.x, 0,
                              JoystickLeft.JosticValue.y)*MovmentSpeed);
    }

    public void Shoting()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
        _direction = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(_direction, out hit, _distance))
        {
            if (hit.collider.tag == "Enemy")
            {
                EnemyTarget = hit.transform.GetComponent<Enemy>();
            }
        }

    }
}
