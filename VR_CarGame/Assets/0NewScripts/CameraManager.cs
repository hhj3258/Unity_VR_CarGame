﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //private GameObject focus;
    private GameManager gManager;

    [SerializeField]
    protected OutterCamera outterCamera;

    [Serializable]
    protected class OutterCamera
    {
        public float distance;
        public float height;
        public float dampening;
    }

    [SerializeField]
    protected InnerCamera innerCamera;

    [Serializable]
    protected class InnerCamera
    {
        public float h2;
        public float d2;
        public float l;
    }

    public static bool camMode = true;

    void Awake()
    {
        gManager = GameManager.Instance;
    }

    private void Update()
    {
        try
        {

            if (Input.GetButtonDown("Fire3") || Input.GetKeyDown(KeyCode.C))
            {
                camMode = camMode ? false : true;
            }

            //바깥 카메라
            if (camMode && Time.timeScale==1)
            {
                transform.position = Vector3.Lerp(transform.position,
                    gManager.MyCar.transform.position + gManager.MyCar.transform.TransformDirection(new Vector3(0f, outterCamera.height, -outterCamera.distance)),
                    outterCamera.dampening * Time.deltaTime);

                transform.LookAt(gManager.MyCar.transform);
                //Camera.main.fieldOfView = 60f;
            }

            if (camMode && Time.timeScale == 0)
            {
                transform.position = Vector3.Lerp(transform.position,
                    gManager.MyCar.transform.position + gManager.MyCar.transform.TransformDirection(new Vector3(0f, outterCamera.height, -outterCamera.distance)),
                    outterCamera.dampening);

                transform.LookAt(gManager.MyCar.transform);
                //Camera.main.fieldOfView = 60f;
            }

            if (!camMode)
            {
                transform.position = gManager.MyCar.transform.position + gManager.MyCar.transform.TransformDirection(new Vector3(innerCamera.l, innerCamera.h2, -innerCamera.d2));

                transform.rotation = gManager.MyCar.transform.rotation;
                //Camera.main.fieldOfView = 80f;
            }
        }
        catch(Exception e)
        {
            
        }


    }

}
