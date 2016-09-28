using UnityEngine;
using System.Collections;

public class rotateToPlayer : MonoBehaviour {

    public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var targetPosition = target.position;
		targetPosition.y = transform.position.y;
		transform.LookAt(targetPosition);	
	}
}
