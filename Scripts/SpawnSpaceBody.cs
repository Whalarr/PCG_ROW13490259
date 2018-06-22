using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpaceBody : MonoBehaviour
{

    public bool Orks_Winning;


    public GameObject[] Team1Bodies;
    public GameObject[] Team2Bodies;
    public GameObject Null;

    GameObject ship_body1;
    GameObject ship_body2;

    public int Team1_ShipCount;
    public int Team2_ShipCount;

     int scale;

    public int ShipCount_Min;
    public int ShipCount_Max;


  
    public static GameObject[] Hexspawns_Array;
    public static Vector3[] HexSpawns_Pos;

    public GameObject Hex_Spawnpoint;
    Vector3 SpawnLoc;

    // Use this for initialization
   

    void Start ()
    {  
            SpawnRandomBody(ship_body1, ship_body2);
        


    }

    // Update is called once per frame
    void Update ()
    {
        if (Team1_ShipCount > Team2_ShipCount)
        {
            Orks_Winning = true;
        }
        else
            Orks_Winning = false;

      
    }


    public void SpawnRandomBody(GameObject body1, GameObject body2)
    {
        int Team_pick = Random.Range(0,15);
        
        if(Team_pick == 0)
        {
            GameObject Random_Body1 = Team1Bodies[Random.Range(0, Team1Bodies.Length)];
            body1 = Instantiate(Random_Body1, Hex_Spawnpoint.transform.position, Quaternion.Euler(-90, 0, 90));
            Team1_ShipCount++;
        }

        if (Team_pick == 1)
        {
            GameObject Random_Body2 = Team2Bodies[Random.Range(0, Team2Bodies.Length)];
            body2 = Instantiate(Random_Body2, Hex_Spawnpoint.transform.position, Quaternion.Euler(0, 90, 0));
            Team2_ShipCount++;
        }
        else
        {
            body1 = Instantiate(Null, Hex_Spawnpoint.transform.position, Quaternion.Euler(0, 90, 0));
            body2 = Instantiate(Null, Hex_Spawnpoint.transform.position, Quaternion.Euler(0, 90, 0));
        }
    return;
    }
}
