using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScroll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Fall();
	}

    //Simulated gravity basically. 
    void Fall()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, -2);
    }
}
