using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRandomizer : MonoBehaviour
{

    public Material[] skyBox;
    public float speed;

    // Use this for initialization
    void Start ()
    {
        RenderSettings.skybox = skyBox[Random.Range(0, skyBox.Length)];
    }
	
	void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed);
    }
}
