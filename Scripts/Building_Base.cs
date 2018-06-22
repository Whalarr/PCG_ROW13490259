using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Base : MonoBehaviour {

    public GameObject[] Floor1_objects;
    public Transform Buildings;

	// Use this for initialization
	void Start ()
    {
        
	}
     void Awake()
    {
        Build_FirstFloor();
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    void Build_FirstFloor()
    {
        GameObject Floorpick = Floor1_objects[UnityEngine.Random.Range(0, Floor1_objects.Length)];

        Instantiate(Floorpick, this.transform.position ,this.transform.rotation, Buildings);

        
    }

}
