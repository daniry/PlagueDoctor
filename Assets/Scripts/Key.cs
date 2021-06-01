using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour {

    public OpenDoor myDoor;
    private AudioSource audioSource;
    public AudioClip pickupSound;
    public Text Counter;
    public int count = 0; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void UnlockDoor()
    {
        myDoor.isLocked = false;

        audioSource.PlayOneShot(pickupSound);
        StartCoroutine("WaitForSelfDest");
    
       
    }

    IEnumerator WaitForSelfDest()
    {
        yield return new WaitForSeconds(pickupSound.length);
        Destroy(gameObject);
        count += 1;
        Counter.text = (count).ToString();
    }
	
}
