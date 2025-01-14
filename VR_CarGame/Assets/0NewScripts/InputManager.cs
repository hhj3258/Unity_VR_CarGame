﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InputManager : MonoBehaviour
{
    public float accel;
    public float steer;
    public bool brake;

    public Camera cam;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Lobby.controller)
            InputCardBoard();
        else
            InputPC();

    }

    void InputCardBoard()
    {
        accel = Input.GetAxis("Fire1");
        steer = Mathf.Clamp(cam.transform.localRotation.z * -2.5f, -1f, 1f);    //2.5배 더 잘 꺾이도록
        //Debug.Log(cam.transform.localRotation.z);
    }

    void InputXbox()
    {
        accel = Input.GetAxis("RTrigger");
    }

    void InputPC()
    {
        steer = Input.GetAxis("Horizontal");
        accel = Input.GetAxis("Vertical");
        brake = Input.GetButton("Jump");    //Space
    }
}
