using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScapePicker : MonoBehaviour {

    public AudioClip[] soundscape_generic;
   
    public AudioClip OrkWin_Sound;
    public AudioClip TauWin_Sound;

    public AudioSource soundscape_source;

    public AudioClip Selected_Audio;

    public GameObject Manager;

    public float percentage;

    public void Start()
    {
       
        //Soundscape_select();

        Generic_Select();
        Soundscape_Play();
       
    }

    public void Update()
    {
        
        
    }


   void Soundscape_select()
    {
        float Ork_Count = Manager.GetComponent<SpawnSpaceBody>().Team1_ShipCount;
        float Tau_Count = Manager.GetComponent<SpawnSpaceBody>().Team2_ShipCount;


        if (Ork_Count > Tau_Count)
        {
            percentage = (Ork_Count / Tau_Count) * 100;
            if (percentage > 70)
            {
                Selected_Audio = OrkWin_Sound;
            }
            else
            {
                Selected_Audio = soundscape_generic[Random.Range(0, soundscape_generic.Length)];
            }
        }
       

        if (Tau_Count > Ork_Count)
        {
            if (percentage < 70)
            {
                Selected_Audio = TauWin_Sound;
            }

            else
            {
                Selected_Audio = soundscape_generic[Random.Range(0, soundscape_generic.Length)];
            }

        }

       
          
    }

    void Generic_Select()
    {
        Selected_Audio = soundscape_generic[Random.Range(0, soundscape_generic.Length)];
        soundscape_source.clip = Selected_Audio;
    }

    void Soundscape_Play()
    {
        soundscape_source.PlayOneShot(Selected_Audio);
    }

}
