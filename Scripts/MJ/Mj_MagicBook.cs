using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mj_MagicBook : MonoBehaviour {

    public Transform _camera;
    public Transform _handPos;

    public Mj_GearVRRaycastController _gearVRayCastController;       

    public GameObject[] arrays;

    public void MagicToRow(int index1)
    {      
        Instantiate(arrays[index1], _handPos.position, _camera.rotation);
    }

    public void MagicToRow(int index1,Transform contolpos)
    {
        Instantiate(arrays[index1], contolpos.position,contolpos.rotation);
    }

    public void MagicRaycast(int index1)
    {

        Ray ray = _gearVRayCastController._ray;
        RaycastHit _hit = new RaycastHit();

        if (Physics.Raycast(ray, out _hit, Mathf.Infinity))
        {
            Vector3 _magicPoint = _hit.point;
            Instantiate(arrays[index1], _hit.point, _camera.rotation);
        }
    }
}
