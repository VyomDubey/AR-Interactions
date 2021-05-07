using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class DetectTouch : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject ArmRig;
    private GameObject target;
    private GameObject LeftArm,RightArm;
    private GameObject LeftLeg,RightLeg;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        LeftArm = GameObject.FindGameObjectWithTag("LeftArm");
        RightArm = GameObject.FindGameObjectWithTag("RightArm");
        LeftLeg = GameObject.FindGameObjectWithTag("LeftLeg");
        RightLeg = GameObject.FindGameObjectWithTag("RightLeg");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.touchCount>0 && Input.touches[0].phase==TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider!=null && hit.collider.tag=="Player")
                {
                        if (target.transform.position.y == 0.74f)
                            {
                        
                                target.transform.position =new Vector3(target.transform.position.x, 0.1f,target.transform.position.z);
                            }
                            else
                            {
                                target.transform.position = new Vector3(target.transform.position.x, 0.74f, target.transform.position.z);
                            }
                        
                }
            }
        }*/
        
    }

    public void OnButtonPressed(string ActionName)
    {
        if (ActionName == "RightArm")
        {
            RightArm.GetComponent<Rig>().weight = Math.Abs(RightArm.GetComponent<Rig>().weight - 1);
        }
        else if (ActionName == "LeftArm")
        {
            LeftArm.GetComponent<Rig>().weight = Math.Abs(LeftArm.GetComponent<Rig>().weight - 1);
        }
        else if (ActionName == "RightLeg")
        {
            RightLeg.GetComponent<Rig>().weight = Math.Abs(RightArm.GetComponent<Rig>().weight - 1);
        }
        else if (ActionName == "LeftLeg")
        {
            LeftLeg.GetComponent<Rig>().weight = Math.Abs(LeftArm.GetComponent<Rig>().weight - 1);
        }
    }


}
