using UnityEngine;
using System.Collections;

public class Animation : MonoBehaviour {

	private Animator anim;
	private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(!rigidbody.velocity.Equals(Vector3.zero)){
			anim.SetBool("isWalking", true);
		} else {
			anim.SetBool("isWalking", false);
		}
	}
}
