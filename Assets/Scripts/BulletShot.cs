using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    private Transform _player;

    private Ray _direction;

    private float _distance = 500;

    public float BulletSpeed;


    private RaycastHit hit;

    [SerializeField] private Enemy _enemyTarget;

	// Use this for initialization
	void Start ()
	{
	    _player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        FindShotTarget();

        }
    private void FindShotTarget()
    {
        _direction = new Ray(_player.position,_player.forward);

            if (Physics.Raycast(_direction, out hit, _distance))
            {

                transform.position = Vector3.Lerp(transform.position, hit.transform.position, BulletSpeed);
                if (Vector3.Distance(transform.position, hit.transform.position) < 2)
                {
                if (hit.collider.tag == "Enemy")
                {
                    _enemyTarget = hit.transform.GetComponent<Enemy>();
                    _enemyTarget.SlideArea.value = _enemyTarget.SlideArea.value - 1;
                }
                Destroy(gameObject);
                }
            }
     }
}
