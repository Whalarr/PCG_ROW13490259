using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Dialogue : MonoBehaviour {

    public AudioClip[] Dialogue;
    public AudioSource Barker;

    AudioClip Picked_Dialogue;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine("Shout");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    IEnumerator Shout()
    {
        float Wait_Time = Random.Range(15, 45);
        Pick_Dialogue();
        Play_Dialogue();

        yield return new WaitForSeconds(Wait_Time);
        StartCoroutine("Shout");
    }

    void Pick_Dialogue()
    {
        Picked_Dialogue = Dialogue[Random.Range(0, Dialogue.Length)];
        Barker.clip = Picked_Dialogue;
    }

    void Play_Dialogue()
    {
        Barker.PlayOneShot(Picked_Dialogue);
    }

}
