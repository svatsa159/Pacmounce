using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{
    public float speed;
    private int p;
    private Rigidbody rb;
    private bool canjump;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        canjump=true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.R))
          {
            Time.timeScale=1;
            gm.food=87;
            SceneManager.LoadScene(0);

            }  

        if (Input.GetKeyDown ("space")) {
            if (canjump == true){
            Vector3 up = transform.TransformDirection (Vector3.up);
             rb.AddForce (up * 15, ForceMode.Impulse);
             canjump=false;
            }
             
         }
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
             Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * -speed);
             
         }
         else{
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //rb.AddForce(rb.position + movement * speed);
            transform.Translate(movement * speed * Time.deltaTime);
            
         }
        if (transform.position.x >= 96)
        {
            transform.position = new Vector3(-77,transform.position.y,transform.position.z);
        }
        if (transform.position.x <= -80)
        {
            transform.position = new Vector3(94, transform.position.y, transform.position.z);
        }

    }
    public void OnTriggerEnter (Collider c) {
        if (c.gameObject.tag=="Static") {
            
            canjump = true;
            
        }
    }

}
