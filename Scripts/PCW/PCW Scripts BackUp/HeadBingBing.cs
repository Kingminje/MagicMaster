using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBingBing : MonoBehaviour {

    public Transform _eye; // 카메라 참조
    public Transform _head; // 마법사 머리 참조

    void LateUpdate () {

        float eyeRotY = _eye.rotation.y; // 카메라 y 회전값
        float eyeRotX = _eye.rotation.x; // 카메라 x 회전값

        // 카메라의 y 회전 값이 머리의 x, 카메라의 x 회전 값이 머리의 y 로 가야 함

        _head.rotation = _eye.rotation;
        
    }
}
