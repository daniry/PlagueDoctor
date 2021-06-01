using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip pickupSound;
    public GameObject noteUI;


    void Start()
    {
        noteUI.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if ((Input.GetMouseButtonDown(0)))
        {
            noteUI.SetActive(false);
        }
    }

    public void ReadNote()
    {
        audioSource.PlayOneShot(pickupSound);
        StartCoroutine("WaitForSelfDest");

       
    }

    IEnumerator WaitForSelfDest()
    {
        yield return new WaitForSeconds(1);
        //Destroy(gameObject);
        noteUI.SetActive(true);
        
    }
}
