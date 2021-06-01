using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Interact : MonoBehaviour {

    public string InteractButton;
    public float InteractDist = 1.5f;
    public LayerMask InteractLayer;
    public Image InteractIcon;
    public Text InteractText1;
    public Text InteractText2;
    public Text InteractText3;
    public GameUI gameUI;
    public GameObject gameWinUI;
    public bool isInteracting;


	// Use this for initialization
	void Start () {
		if(InteractIcon != null)
        {
            InteractIcon.enabled = false;
            InteractText1.enabled = false;
            InteractText2.enabled = false;
            InteractText3.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, InteractDist, InteractLayer)) {
            if(isInteracting == false)
            {
                if(InteractIcon != null && InteractText1 != null && InteractText2 != null)
                {
                    InteractIcon.enabled = true;
                    if(hit.collider.CompareTag("Key") || hit.collider.CompareTag("Note")) { 
                        InteractText1.enabled = true; 
                    }
                    if (hit.collider.CompareTag("Door"))
                    {
                        InteractText2.enabled = true;
                    }
                    if (hit.collider.CompareTag("Door_Finish"))
                    {
                        InteractText3.enabled = true;
                    }

                }
                if(Input.GetKeyDown(KeyCode.E) && hit.collider.CompareTag("Key"))
                {
                    hit.collider.GetComponent<Key>().UnlockDoor();
                    
                }
                if (Input.GetKeyDown(KeyCode.E) && hit.collider.CompareTag("Note"))
                {
                    hit.collider.GetComponent<Note>().ReadNote();

                }
                if (Input.GetKeyDown(KeyCode.E) && hit.collider.CompareTag("Door_Finish"))
                {
                    //hit.collider.GetComponent<Key>().UnlockDoor();
                    isInteracting = true;
                    InteractText3.enabled = false;
                    InteractIcon.enabled = false;
                    gameWinUI.SetActive(true);
                    gameUI.player_mov.enabled = false;
                }
            }
        }
        else
        {
            InteractIcon.enabled = false;
            InteractText1.enabled = false;
            InteractText2.enabled = false;
            InteractText3.enabled = false;
        }
	}
}
