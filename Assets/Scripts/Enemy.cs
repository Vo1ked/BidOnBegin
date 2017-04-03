using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Text TextArea;
    public Slider SlideArea;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (SlideArea.value <1)
	    {
	        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().EnemyTarget = null;
            Destroy(gameObject);

        }
    }

    public void EnemyHit(float damage)
    {
        SlideArea.value -= damage;
    }
}
