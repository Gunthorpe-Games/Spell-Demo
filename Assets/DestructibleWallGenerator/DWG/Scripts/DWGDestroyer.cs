using UnityEngine;
using System.Collections;

public class DWGDestroyer : MonoBehaviour {

	public float radius = 2;
	
	void OnTriggerEnter(Collider col){
        if (col.gameObject.CompareTag("Destructible"))
        {
            ExplodeForce();
        }
	}
	
	// Explode force by radius only if a destructible tag is found
	void ExplodeForce(){
		Vector3 explodePos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explodePos, radius); 
		foreach (Collider hit in colliders){
			if(hit.GetComponent<Collider>().tag == "Destructible"){
				if(hit.GetComponent<Rigidbody>()){
					hit.GetComponent<Rigidbody>().isKinematic = false; 
					hit.GetComponent<Rigidbody>().AddExplosionForce(GetComponent<Rigidbody>().velocity.magnitude * 200, explodePos,radius);
				}
			}
		}
	}
}
