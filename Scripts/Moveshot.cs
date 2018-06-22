using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveshot : MonoBehaviour
{

    float timer = 0;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.forward * 0.8f);

        if (this.tag == "Ork-Shot")
        {
            this.transform.Translate(-transform.forward * 0.8f);

        }

        timer++;

        if (timer >= 30)
        {
            DestroyObject(gameObject);
        }
    }
}
