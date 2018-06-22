using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAstClusters : MonoBehaviour
{
    

    public GameObject Ast_Group;

    public int Asteroid_Count;

    public GameObject[] Asteroids;
    public GameObject[] Ork_Asteroids;
    public GameObject[] Tau_Asteroids;

    GameObject Asteroid_Picker1;
    GameObject Asteroid_Picker2;

    public Vector3 Centre;
    public float Min_Dist;
    public float Max_Dist;


    Vector3 Sphere;
    Vector3 Sphere2;
    // Use this for initialization
    void Start ()
    {

         for (int i = 0; i < Asteroid_Count; i++)
        {

            Asteroid_Spawn();
            Spawn_Sphere();
        }
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        


	}

    void Spawn_Sphere()
    {
       
        Sphere = Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), Vector3.up) * Vector3.forward;
        Sphere2 = Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), Vector3.up) * Vector3.forward;
        Sphere = Sphere * Random.Range(Min_Dist, Max_Dist);
        Sphere2 = Sphere2 * Random.Range(Min_Dist, Max_Dist);
    }

void Asteroid_Spawn()
    {
        int ast_pick = Random.Range(1,10);


        Asteroid_Picker1 = Asteroids[Random.Range(0, Asteroids.Length)];
        var ast = Instantiate(Asteroid_Picker1, Centre + Sphere, Quaternion.Euler(0, 0, 0), Ast_Group.transform);
        ast.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(1, 5), Random.Range(1, 5), Random.Range(1, 5));

        if (ast_pick <= 6)
        {
            Asteroid_Picker2 = Ork_Asteroids[Random.Range(0, Ork_Asteroids.Length)];
            var ast2 = Instantiate(Asteroid_Picker2, Centre + Sphere2, Quaternion.Euler(0, 0, 0), Ast_Group.transform);
            ast2.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(1, 5), Random.Range(1, 5), Random.Range(1, 5));
        }
        if (ast_pick >= 5)
        {
            Asteroid_Picker2 = Tau_Asteroids[Random.Range(0, Tau_Asteroids.Length)];
            var ast2 = Instantiate(Asteroid_Picker2, Centre + Sphere2, Quaternion.Euler(0, 0, 0), Ast_Group.transform);
            ast2.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(1, 5), Random.Range(1, 5), Random.Range(1, 5));

        }
       

    }
}
