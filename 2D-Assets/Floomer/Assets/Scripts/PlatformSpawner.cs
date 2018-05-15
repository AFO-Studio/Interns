using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
    public GameObject platform;
    public GameObject coin;
    public GameObject chest;
    public GameObject enemy;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Spawner());
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator Spawner()
    {
        while(true)
        {
            Instantiate(platform, new Vector2(Random.Range(-7f, 7f) , 7f), Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
}
