using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour {

	public float smooth = 2.0f;
	public float DoorOpenAngle = -90.0f;

	public AudioClip OpenAudio;
	public AudioClip CloseAudio;
    public AudioClip lockedDoorSound;
    private AudioSource audioSource;

	private bool AudioS;

	private Vector3 defaultRot;
	private Vector3 openRot;
	private bool open = false;
	private bool enter;

    public bool isLocked = false;

    // Use this for initialization
    void Start () {
		
			defaultRot = transform.eulerAngles;
			openRot = new Vector3 (defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
    }

    
	
	// Update is called once per frame
	void Update () {
        if (isLocked != true)
        {
            if (open)
            {
                if (AudioS == false)
                {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(OpenAudio);
                    AudioS = true;
                }
                transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
            }
            else
            {
                if (AudioS == true)
                {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(CloseAudio);
                    AudioS = false;
                }
                transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);

            }
        }

        if (Input.GetKeyDown(KeyCode.E) && enter && isLocked != true)
        {
            open = !open;
        }
        else if (Input.GetKeyDown(KeyCode.E) && enter && isLocked != false) { gameObject.GetComponent<AudioSource>().PlayOneShot(lockedDoorSound); }
    }

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") {
			enter = true;
        }
		}

    void OnTriggerExit(Collider col)
{
	if (col.tag == "Player") {
		enter = false;
	}
}
}