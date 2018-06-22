using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadSpawner : MonoBehaviour {

    public GameObject Ork_Nobz;
    public GameObject Tau_warrior;
    public GameObject Squad_Parent;
    public int Squad_Size;
    public int Squad_Count;
    public Terrain TerrainObj;


	// Use this for initialization
	void Start ()
    {
       
        CreateSquad();
       
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void CreateSquad()
    {
        
        int Team_Picker = Random.Range(0, 5);

        Squad_Size = 1;

     
            for (int y = 0; y < Squad_Size; y++)
            {
               if(Team_Picker == 0)
                {
                    Vector3 Ork_SpawnPos = Vector3.zero;
                    Ork_SpawnPos.x = this.transform.position.x + Random.Range(-3, 3);
                    Ork_SpawnPos.z = this.transform.position.z + Random.Range(-3, 3);
                    Ork_SpawnPos.y = TerrainObj.SampleHeight(Ork_SpawnPos) - 1.5f;
                    Ork_Nobz.transform.parent = Squad_Parent.transform;

                    Instantiate(Ork_Nobz, Ork_SpawnPos, Quaternion.Euler(0, 0, 0));
                }
               if(Team_Picker == 1)
            {
                Vector3 Tau_SpawnPos = Vector3.zero;
                Tau_SpawnPos.x = this.transform.position.x + Random.Range(-3, 3);
                Tau_SpawnPos.z = this.transform.position.z + Random.Range(-3, 3);
                Tau_SpawnPos.y = TerrainObj.SampleHeight(Tau_SpawnPos) - 1.5f;


                Instantiate(Tau_warrior, Tau_SpawnPos, Quaternion.Euler(0, 0, 0));


                Tau_warrior.transform.parent = Squad_Parent.transform;
            }
            else
            {

            }       
            
        }
    }
}
