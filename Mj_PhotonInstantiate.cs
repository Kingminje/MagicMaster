using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mj_PhotonInstantiate : Photon.MonoBehaviour {

    private Vector3 _randomValue;

    private bool ckPlayer = false;

    //public void rOnPhotonPlayerConnected ()

    private void Start()
    {
        float PosX = Random.Range(-40f, 40f);
        float PosZ = Random.Range(-40f, 40f);
        _randomValue = new Vector3(PosX, 2.6f, PosZ);
    }


    [PunRPC]
    public void PlayerChange()
    {
        if (photonView.isMine)
        {
            GameObject localPlayer = PhotonNetwork.Instantiate("Prefabs/[photonTest]PlayerOvr", _randomValue, Quaternion.identity, 0);
        }

    }



    //public void OnPhotonPlayerConnected(PhotonPlayer _player)
    //{
    //    if (pho)
    //    {
    //        float PosX = Random.Range(-40f, 40f);
    //        float PosZ = Random.Range(-40f, 40f);
    //        _randomValue = new Vector3(PosX, 2.6f, PosZ);
    //        // 포톤 네트워크 오브젝트(동기화 오브젝트)를 생성함
    //        // * 모든 포톤 네트워크 오브젝트에는 PhotonView 컴포넌트가 추가되어야 함
    //        // PhotonNetwork.Instantiate("Resources폴더를 기준으로, 하위 경로를 포함한 프리팹 이름", 생성 위치, 회전, 전달할 데이터);
    //        GameObject localPlayer = PhotonNetwork.Instantiate("Prefabs/[photonTest]PlayerOvr", _randomValue, Quaternion.identity, 0);
    //        Destroy(gameObject);
    //        Debug.Log("주인공 등장");
    //    }
    //    else
    //    {
    //        GameObject localPlayer = PhotonNetwork.Instantiate("Prefabs/[photonTest]PlayerOvr2", _randomValue, Quaternion.identity, 0);
    //        Destroy(gameObject);
    //        Debug.Log("악당 등장");
    //    }        
    //}

    //public void PotonInstantiate()
    //{
        
    //    if (photonView.isMine)
    //    {
            

    //    }
    //    if (!photonView.isMine)        
    //    {
    //        GameObject localPlayer = PhotonNetwork.Instantiate("Prefabs/[photonTest]PlayerOvr1", _randomValue, Quaternion.identity, 0);
    //        Destroy(gameObject);
    //        Debug.Log("악당 등장");
    //    }
    //}
}
