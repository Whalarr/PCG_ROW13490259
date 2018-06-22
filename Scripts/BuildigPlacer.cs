using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildigPlacer : MonoBehaviour {

    public GameObject[] NextFloor_objects;
    Vector3 Prev_FloorPos;
    Vector3 Next_FloorPos;
    public Transform Building_Block;

    // Use this for initialization
    void Start ()
    {
        Build_NextFloor();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Build_NextFloor()
    {
        GameObject Floorpick = NextFloor_objects[UnityEngine.Random.Range(0, NextFloor_objects.Length)];
        Prev_FloorPos.x = this.transform.position.x;
        Prev_FloorPos.y = this.transform.position.y;
        Prev_FloorPos.z = this.transform.position.z;

        Next_FloorPos.x = this.transform.position.x;
        Next_FloorPos.y = this.transform.position.y + this.transform.localScale.y;
        Next_FloorPos.z = this.transform.position.z;



        Instantiate(Floorpick, Next_FloorPos, this.transform.rotation, Building_Block);



    }
}
