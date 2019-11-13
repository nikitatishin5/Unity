using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIfGrabber : MonoBehaviour
{

    private SimpleShoot simpleShoot;
    public OVRGrabbable ovrGrabbable;
    public OVRInput.Button shootingButton;
    // Start is called before the first frame update
    void Start()
    {
        simpleShoot = GetComponent<SimpleShoot>();
        //ovrGrabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(ovrGrabbable.isGrabbed && OVRInput.GetDown(shootingButton,ovrGrabbable.GetController()))
        //{
        //    simpleShoot.TriggerShoot();
        //}
        
    }
}
