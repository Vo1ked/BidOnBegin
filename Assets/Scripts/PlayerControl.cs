using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public float MovmentSpeed = 0.1f;
    private float _distance = 5000;

    public JoystickMoving JoystickLeft;
    [SerializeField] private CharacterController _charterMove;

    private Transform _playerPos;

    public GameObject BulletStorage;

    private Ray _direction;

    private RaycastHit hit;

    public Enemy EnemyTarget;

    private int _bulletNum;
    private int _bulletCap;




    // Use this for initialization
    void Start()
    {
        _bulletCap = BulletStorage.transform.childCount;
        _bulletNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CharterMove();

    }

    private void CharterMove()
    {
        _charterMove.Move(new Vector3(JoystickLeft.JosticValue.x, 0,
                              JoystickLeft.JosticValue.y)*MovmentSpeed);
    }

    public void Shoting()
    {

        //Instantiate(Bullet, transform.position, transform.rotation);
        BulletStorage.transform.GetChild(_bulletNum).gameObject.SetActive(true);
        BulletStorage.transform.GetChild(_bulletNum).GetComponent<BulletShot>().ShotPos();
        _bulletNum++;
        if (_bulletNum == _bulletCap)
        {
            _bulletNum = 0;
        }

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
