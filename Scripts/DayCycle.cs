using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour {

    public Light MainLight;
    public Light RimLight;

	// Use this for initialization
	void Start ()
    {
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        MainLight.intensity = Mathf.Sin(Time.time * 0.5f) * 0.8f;
        RimLight.intensity = MainLight.intensity / 2;
	}

}
