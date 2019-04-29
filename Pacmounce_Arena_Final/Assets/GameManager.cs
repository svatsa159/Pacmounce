using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
	public float score=0;
	public int lives=6;
	public Text text_canvas;
	public Text GameOver;
    public Text RestartText;
	public int food;
	public Text Lives;
	public Transform Food;
	bool paused;
    // Start is called before the first frame update
    void Start()
    {
        food=87;
        Lives.text="Lives Remaining :"+lives;
        text_canvas.text= "Score :"+score.ToString();
         
    }

    // Update is called once per frame
    void Update()
    {
       
       if(Food.childCount==0){
        GameOver.text= "Game Completed";
        RestartText.text = "R to Restart";
        Time.timeScale=0;
       }
    	
        if (Input.GetKeyDown(KeyCode.P)) {
           if(paused){
           	Time.timeScale=1;
           	paused=false;
             
         }
         else{
         	Time.timeScale=0;
         	paused=true;
         }
           }
           if (Input.GetKeyDown(KeyCode.Q)) {
          
            Application.Quit();
          }
    }

    public void increaseScore(float val)
    {
    	score+=val;
    	text_canvas.text= "Score :"+score.ToString();
    		Debug.Log(score);
    }
    public void reset(){
    	
    	
    	lives--;
    	Lives.text="Lives Remaining :"+lives;
    		
    	if(lives<=0){
    		GameOver.text= "Game Over";
            RestartText.text = "R to Restart";
    		Time.timeScale=0;
    	}
    	
    }
   

     
}
