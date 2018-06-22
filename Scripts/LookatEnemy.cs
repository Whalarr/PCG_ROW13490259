using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatEnemy : MonoBehaviour
{

    public GameObject Target;
    public GameObject Laser;
    

    // Use this for initialization
    void Start()
    {
        TeamPick();
        StartCoroutine("Shoot");
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void TeamPick()
    {
     

        if (this.tag == "Ork-Warrior")
        {
            Target = GameObject.FindGameObjectsWithTag("Tau-Warrior")[Random.Range(0, GameObject.FindGameObjectsWithTag("Tau-Warrior").Length)];
            this.transform.LookAt(Target.transform);
        }
        if(this.tag == "Tau-Warrior")
        {
            Target = GameObject.FindGameObjectsWithTag("Ork-Warrior")[Random.Range(0, GameObject.FindGameObjectsWithTag("Ork-Warrior").Length)];
            this.transform.LookAt(Target.transform);
        }
        if (this.tag == "Ork-Ship")
        {
            Target = GameObject.FindGameObjectsWithTag("Tau-Ship")[Random.Range(0, GameObject.FindGameObjectsWithTag("Tau-Ship").Length)];
            this.transform.LookAt(Target.transform);
            this.transform.Rotate(new Vector3(transform.rotation.x - 90, transform.rotation.y, transform.rotation.z));
        }
        if (this.tag == "Tau-Ship")
        {
            Target = GameObject.FindGameObjectsWithTag("Ork-Ship")[Random.Range(0, GameObject.FindGameObjectsWithTag("Ork-Ship").Length)];
            this.transform.LookAt(Target.transform);
        }

       

       
    }
   
    IEnumerator Shoot()
    {
        float timebetween = Random.Range(1f, 5f);
        Fire();
        yield return new WaitForSeconds(timebetween);
        StartCoroutine("Shoot");
    }

    void Fire()
    {
        Instantiate(Laser, this.transform.position + new Vector3(0,0.5f,0), this.transform.rotation);
    }
}
