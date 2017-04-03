using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    private GameObject _player;

    public float BulletSpeed;

    private Enemy _enemyTarget;


	// Use this for initialization
	void Start ()
	{
	    _player = GameObject.FindGameObjectWithTag("Player");
	    _enemyTarget = _player.GetComponent<PlayerControl>().EnemyTarget;
        Destroy(gameObject,3);
	}
	
	// Update is called once per frame
	void Update () {
        FindShotTarget();

        }
    private void FindShotTarget()
    {
        transform.position += transform.forward*Time.deltaTime*BulletSpeed;
        if (_enemyTarget != null)
            if (Vector3.Distance(transform.position, _enemyTarget.transform.position) < 1)
                {
                _enemyTarget.EnemyHit(Random.Range(1,5));
                Destroy(gameObject);
                }
            }
     }
