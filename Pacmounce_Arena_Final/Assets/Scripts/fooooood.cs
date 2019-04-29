using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fooooood : MonoBehaviour
{
	Vector3 originalPos;
    public GameManager gm;
   	
    void Start(){
    	originalPos = gameObject.transform.position;	
    }
   	
    public void OnTriggerEnter(Collider coll){
		      if(coll.gameObject.tag == "Food"){
		      	// Debug.Log("sssup");
		        Destroy(coll.gameObject);
		        gm.food--;
		        gm.increaseScore(1f);
		      }
		      if(coll.gameObject.tag == "Cherry"){
		      	// Debug.Log("sssup");
		        Destroy(coll.gameObject);
		        gm.food--;
		        gm.increaseScore(5f);
		      }
		      if(coll.gameObject.tag == "Enemy"){
		      	// Debug.Log("sssup");
		       	gameObject.transform.position = originalPos;
		        gm.reset();

		      }

		 }
		 
}
