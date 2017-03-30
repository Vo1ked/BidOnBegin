using UnityEngine;
using System.Collections;

public class HideErrorMessage : MonoBehaviour
{
    [SerializeField] private GameObject _errorMessage;

	// Use this for initialization
	void Start () {
	_errorMessage.transform.localScale = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
