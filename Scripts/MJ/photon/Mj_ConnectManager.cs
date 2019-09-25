using UnityEngine;
using UnityEngine.UI;

// [포톤 네트워크 망 구조]
// 클라이언트 <-> 포톤방 .... x n <-> 포톤로비 <-> 포톤클라우드

// [포톤 접속 순서]
// 1. 포톤 클라우드 접속
// 2. 포톤 로비 생성 및 접속 (자동 접속 설정 가능)
// 3. 포톤 방 생성 및 접속

// [포톤 방 관련 주요 메소드]
// PhotonNetwork.CreateRoom(...) : 포톤 로비에 방을 생성함 (* 방을 생성한 사람(방장)은 자동으로 방에 접속됨)
// PhotonNetwork.JoinRoom(...) : 생성된 방에 접속함
// PhotonNetwork.JoinRandomRoom(...) : 생성된 방 중에 랜덤하게 접속함
// PhotonNetwork.JoinOrCreateRoom(...) : 접속하려는 방이 없으면 생성하고, 방이 있으면 접속을 시도함

// [포톤 네트워킹 이벤트 종류]
// Enums.cs - enum PhotonNetworkingMessage 확인


public class Mj_ConnectManager : Photon.MonoBehaviour
{
    //public Text _msgText;   // 메시지 출력 텍스트
    public static bool ConnectdPlayer = false;
    
    private Vector3 _randomValue;
    
    private void Awake()
    {
        // 포톤 클라우드에 접속된 상태가 아니면
        if (!PhotonNetwork.connected)
        {
            // 포톤 클라우드 접속 및 로비 접속
            PhotonNetwork.ConnectUsingSettings("v1.0");

            //_msgText.text = "[정보] 서버 접속 및 로비 생성을 시도함";
        }
        float PosX = Random.Range(-40f, 40f);
        float PosZ = Random.Range(-40f, 40f);
        // 랜덤한 위치를 필드 타입 변수에 대입
        _randomValue = new Vector3(PosX, 2.6f, PosZ); 
    }

    /// Photon Event : 로비 접속이 완료되었을 때 호출됨
    public void OnJoinedLobby()
    {
        //포톤 클라우드 및 로비 접속이 완료됨
        PhotonNetwork.JoinOrCreateRoom(
            "Room",
            new RoomOptions()
            {
                MaxPlayers = 10,    // 최대 접속 가능 인원
                IsOpen = true,  // 접속 가능 여부
                IsVisible = true    // 찾기 가능 여부
        },
            TypedLobby.Default);
        //로비에 생성된 방에 접속을 시도함
    }
        
    // Photon Event : 포톤 로비에 생성된 방에 접속이 완료되었을 때 호출됨
    public void OnJoinedRoom()
    {
        //_msgText.text = "[정보] 로비에 생성된 방에 접속함";

        //GameObject localCk = PhotonNetwork.Instantiate("Prefabs/CkPlayer", new Vector3(0f, 0f, 0f), Quaternion.identity, 0);

        GameObject localPlayer = PhotonNetwork.Instantiate("Prefabs/[photonTest]PlayerOvr", _randomValue, Quaternion.identity, 0);            
        Debug.Log("주인공 등장");

        //if (photonView.isMine)
        //{
        //    // 포톤 네트워크 오브젝트(동기화 오브젝트)를 생성함
        //    // * 모든 포톤 네트워크 오브젝트에는 PhotonView 컴포넌트가 추가되어야 함
        //    // PhotonNetwork.Instantiate("Resources폴더를 기준으로, 하위 경로를 포함한 프리팹 이름", 생성 위치, 회전, 전달할 데이터);
        //    GameObject localPlayer = PhotonNetwork.Instantiate("Prefabs/[photonTest]PlayerOvr", _randomValue2, Quaternion.identity, 0);
        //    Destroy(gameObject);
        //    Debug.Log("주인공 등장");

        //}
        //else
        //{
        //    GameObject localPlayer = PhotonNetwork.Instantiate("Prefabs/[photonTest]PlayerOvr2", _randomValue2, Quaternion.identity, 0);
        //    Destroy(gameObject);
        //    Debug.Log("악당 등장");
        //}


    }

    /// Photon Event : 포톤 클라우드 접속에 실패했을 때 호출됨
    public void OnFailedToConnectToPhoton(DisconnectCause err)
    {
        Debug.Log("[오류] 포톤 클라우드 접속에 실패함 : " + err.ToString());
    }

    /// Photon Event : 포톤 로비에 방 생성이 실패됨
    public void OnPhotonCreateRoomFailed(object[] err)
    {
        Debug.Log("[오류] 포톤 로비에 방 생성을 실패함 : " + err[1].ToString());
    }

    /// Photon Event : 포톤 로비에 생성된 방에 접속을 실패함
    public void OnPhotonJoinRoomFailed(object[] err)
    {
        Debug.Log("[오류] 포톤 로비에 생성된 방에 접속을 실패함 : " + err[1].ToString());
    }

    /// Photon Event : 포톤 로비에 생성된 방에 랜덤 접속을 실패함
    public void OnPhotonRandomJoinFailed(object[] err)
    {
        Debug.Log("[오류] 포톤 로비에 생성된 방에 랜덤 접속을 실패함 : " + err[1].ToString());

        // 랜덤 접속을 실패하면, 스스로 방을 생성해야함
    }
}
