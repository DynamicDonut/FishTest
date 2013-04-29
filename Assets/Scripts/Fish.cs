using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {
	
	public float speed = 5f;
	public float stopDistance = 2f;
	Vector3 destination;

	// Use this for initialization
	void Start () {
		SetNewDestination();
	}
	
	// Update is called once per frame
	void Update () {
		//Quaternion.LookRotation takes any Vector3 forward vector convert to crazy Quaternion format we need
		transform.rotation = Quaternion.LookRotation(-rigidbody.velocity);
	}
	
	//Fixedupdate for physics
	void FixedUpdate(){
		//apply a physics force in the direction of our destination
		rigidbody.AddForce( (destination - transform.position).normalized * Time.fixedDeltaTime * speed, ForceMode.Force);	
		//if fish is near our current estination, then set a new destination
		if(Vector3.Distance(transform.position, destination) < stopDistance){
			SetNewDestination();
		}
	}
	
	void SetNewDestination() {
		//set "destination" to a random point inside an imaginary sphere with a radius of 10
		SetNewDestination(Random.insideUnitSphere * 10f);
	}
	
	void SetNewDestination(Vector3 newDestination) {
		destination = newDestination;
	}
}

/*
 * Time.deltaTime for voidUpdate (regular frames)
 * Time.fixedDeltaTime for void FixedUpdate (physics frames)
 */
