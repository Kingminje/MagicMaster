using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mj_PlayerChange : Photon.MonoBehaviour {

    public GameObject _oVRCameraRig;
    //public GameObject _oVRDeathCameraRig;    
    public GameObject _sf_Charactor_Wizard;
    //public GameObject _playerCharacter;


    private void Start()
    {
        if (!photonView.isMine)
        {
            _sf_Charactor_Wizard.layer = 0;            
            _oVRCameraRig.SetActive(false); // 내가 생성한 플레이어 케릭터가 아니라면 디세이브함           
            //_playerCharacter.SetActive(true);


            Debug.Log("..가 아니라 악당이었습니다.");
        }
    }

}
