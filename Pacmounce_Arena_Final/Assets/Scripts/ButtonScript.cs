using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ButtonScript : MonoBehaviour
{
	
private bool paused;
    // Start is called before the first frame update
    void Start()
    {
        
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pausegame(){
    	print("ENTERED");
    	if(paused){
    		Time.timeScale=1;
    		paused=false;
    	}
    	else{
    		Time.timeScale=0;
    		paused=true;
    	}
    }
}
