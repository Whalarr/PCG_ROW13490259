using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {

    public int Seed;

	// Use this for initialization
	void Start ()
    {
        Seed = Random.Range(0, 99999);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
