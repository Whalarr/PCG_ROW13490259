using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{
 

    public GameObject Wing_Left;
    public GameObject Wing_Right;
    public GameObject Ship_Front;
    public GameObject Ship_Back;

    public GameObject Wing_Left_Pos;
    public GameObject Wing_Right_Pos;
    public GameObject Ship_Front_Pos;
    public GameObject Ship_Back_Pos;


    public GameObject[] wings;
    public GameObject[] Fronts;
    public GameObject[] Backs;

    GameObject WingL;
    GameObject WingR;
    GameObject Front;
    GameObject Back;

    public AudioSource Team1_Warcry;

    public AudioClip[] Team1_Sounds;
    AudioClip Team1_SoundPick;

    // Use this for initialization
    void Start ()
    {
        SpawnRandomObj();
        Team1_Warcry.Play();

    }

    // Update is called once per frame
    void Update ()
    {
		
	} 

   

    public  void SpawnRandomObj()
    {
        GameObject Random_WingPicker = wings[UnityEngine.Random.Range(0, wings.Length)];
        GameObject Random_FrontPicker = Fronts[UnityEngine.Random.Range(0, Fronts.Length)];
        GameObject Random_BackPicker = Backs[UnityEngine.Random.Range(0, Backs.Length)];


        Team1_SoundPick = Team1_Sounds[Random.Range(0, Team1_Sounds.Length)];
        Team1_Warcry.clip = Team1_SoundPick;

        if (Wing_Left)
        {             
            Wing_Left = Random_WingPicker;
            WingL = Instantiate(Wing_Left, Wing_Left_Pos.transform.position, Wing_Left_Pos.transform.rotation);          
            WingL.transform.SetParent(Wing_Left_Pos.transform);
            WingL.transform.localScale = new Vector3(1,1,1);
        }
        
        if (Wing_Right)
        {
            Wing_Right = Random_WingPicker;
            WingR = Instantiate(Wing_Right, Wing_Right_Pos.transform.position, Wing_Right_Pos.transform.rotation);
            WingR.transform.SetParent(Wing_Right_Pos.transform);
            WingR.transform.localScale = new Vector3(1, 1, 1);
        }

        if (Ship_Front)
        {
            Ship_Front = Random_FrontPicker;
            Front = Instantiate(Ship_Front, Ship_Front_Pos.transform.position, Ship_Front_Pos.transform.rotation);
            Front.transform.SetParent(Ship_Front_Pos.transform);
            Front.transform.localScale = new Vector3(1, 1, 1);
        }

        if (Ship_Back)
        {
            Ship_Back = Random_BackPicker;
            Back = Instantiate(Ship_Back, Ship_Back_Pos.transform.position, Ship_Back_Pos.transform.rotation);
            Back.transform.SetParent(Ship_Back_Pos.transform);
            Back.transform.localScale = new Vector3(1, 1, 1);
        }

    }
}
