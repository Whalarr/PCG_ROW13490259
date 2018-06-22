using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Burn : MonoBehaviour
{

    public ParticleSystem Smoke;


	// Use this for initialization
	void Start ()
    {
        Burn();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Burn()
    {
        int burn_Pick = Random.Range(1, 15);

        if (burn_Pick == 1)
        {
            Instantiate(Smoke, this.transform.position, this.transform.rotation, this.transform);
        }
        
    }
}
