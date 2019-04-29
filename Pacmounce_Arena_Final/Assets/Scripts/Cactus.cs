using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
	public float diff;
	bool re;
	private float wait;
    // Start is called before the first frame update
    void Start()
    {
        diff=-4.4f;
        re =false;
        wait=3f;
    }

    // Update is called once per frame
    void Update()
    {
    	if(!re){
    		if(wait>0){
        		wait-=0.1f;
        	}
        	else{
    		if(diff<=0){
        	 gameObject.transform.Translate(0, 0, 0.1f);
        	 diff+=0.1f;
        	}
        	else{
        		re=true;
        		wait=3f;
        	}
        }
    	}
        else{
        	if(wait>0){
        		wait-=0.1f;
        	}
        	else{
        		if(diff>=-4.4f){
	        	 gameObject.transform.Translate(0, 0, -0.1f);
	        	 diff-=0.1f;
	        	}
	        	else{
	        		re=false;
	        		wait=3f;
	        	}
        	}
        	
        }
    }
}
