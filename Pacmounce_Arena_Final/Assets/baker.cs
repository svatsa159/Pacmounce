using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class baker : MonoBehaviour
{
	public NavMeshSurface nv;
    // Start is called before the first frame update
    void Awake()
    {
      //  nv = GetComponent<NavMeshSurface>();
    }

    void Start()
    {
    	nv.BuildNavMesh ();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
