using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicBook : MonoBehaviour
{

    public CGameManager _gameMager; // 게임매니저 참조 (현재 사용 안함)
    public Transform _camera;
    public Transform _handPos;

    public Mj_GearVRRaycastController _gearVRayCastController;

    //[System.Serializable]
    //public class Array2
    //{

    //    public GameObject[] arrys = new GameObject[4];
    //}

    //public Array2[] magicprefabss = new Array2[4]/// 클래스를 하나 더 만들어서 꼼수로 어레이안에 어레이를 만든거임.. [,]같음 (사용안함)

    public GameObject[] arrays;

    public void MagicToRow(int index1) // 게임매니저에서 int값 1개 받음,게임매니저에서 int값 2개를 받아서 생성(사용안함)
    {
        //return magicprefabss[index1, index2];

        //if(index1 >= 1)
        //{
        //    MagicRaycast(index1 /*index2*/);
        //}
        //else
        //{
        //    //MagicRaycast(index1, index2);
        //    Instantiate(/*Array2.arrys[index1]*/arrays[index1], _handPos.position, _camera.rotation); (사용안함)
        //}        
        Instantiate(arrays[index1], _handPos.position, _camera.rotation);
    }

    public void MagicRaycast(int index1/*, int index2*/)
    {

        Ray ray = _gearVRayCastController._ray;
        RaycastHit _hit = new RaycastHit();        

        if (Physics.Raycast(ray, out _hit, Mathf.Infinity))
        {
            Vector3 _magicPoint = _hit.point;
            Instantiate(/*magicprefabss[index1].arrys[index2]*/arrays[index1], _hit.point, _camera.rotation);
        }
    }
}
