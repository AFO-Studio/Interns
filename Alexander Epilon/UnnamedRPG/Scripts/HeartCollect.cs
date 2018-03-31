using UnityEngine;
using System.Collections;

public class HeartCollect : MonoBehaviour {
    public int rotateSpeed;
    public AudioSource collectSound;
    public GameObject thisHeart;
	
	// Update is called once per frame
	void Update () {
        rotateSpeed = 2;
        transform.Rotate(0, rotateSpeed, 0, Space.World);
	}
    void onTriggerEnter ()
    {
        collectSound.Play ();
        thisHeart.SetActive(false);
    }



}
