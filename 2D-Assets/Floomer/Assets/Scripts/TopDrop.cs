using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDrop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Reposition();
	}

    //places things that fall back towards the top of the screen.
    void Reposition()
    {
        if(gameObject.transform.position.y <= -7)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, 7.0f);
        }
    }
}
