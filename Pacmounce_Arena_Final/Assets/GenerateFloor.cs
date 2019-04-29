using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFloor : MonoBehaviour
{
    public int width = 50;
    public int breadth = 50;
    public GameObject floor_prefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=-1*width; i<=width; i++)
        {
            for (int j=-1*breadth; j<=breadth; j++)
            {
                GameObject gameObject = Instantiate(floor_prefab, new Vector3(8 * i, 0, 8 * j), Quaternion.Euler(-90, 0, 0));
                gameObject.layer = 13; // Hides from minimap
                gameObject.transform.parent = transform;
            }
        }
        transform.position = new Vector3(0,0.02f,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
