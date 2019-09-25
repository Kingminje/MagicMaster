using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCW_UIBillBoard : MonoBehaviour {

	void LateUpdate () {
        // 현재 UI의 회전값을 카메라의 시선과 일치시킴
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }
}
