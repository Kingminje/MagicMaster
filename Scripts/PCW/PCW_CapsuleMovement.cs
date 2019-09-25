using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCW_CapsuleMovement : MonoBehaviour {

    public Transform _playerPos; // 플레이어 위치
    public Transform _capsulePos; // 캡슐 위치
    public Animator _animator; // 애니메이터 참조
    private Vector3 _destination = new Vector3(0, 0, 0); // 이동할 목적지
    public float _moveDealayTime; // 이동 지연 시간
    public PCW_CapsuleFSM _isMovingOnOff; // FSM에 있는 이동하는 중인가 아닌가
    public GameObject _prefabs;

    public LBJ_CGameManager _gamemanager;


    void Start () {
        Vector3 _capsulePos = gameObject.GetComponent<Transform>().position; // 캡슐 위치 겟컴포넌트
        
        _gamemanager = GameObject.FindGameObjectWithTag ( "manager" ).GetComponent<LBJ_CGameManager>();
        _moveDealayTime = _gamemanager.delaytime;
        if (_moveDealayTime < 0.5f) _moveDealayTime = 0.5f;
        _playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void CapsuleMove()
    {
        if (_playerPos == null) _playerPos =  GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (_isMovingOnOff._isMove) // FSM에 있는 이동 중인가 아닌가
        {
            CapsuleMovementStart();
        }
    }

    private void CapsuleMovementStart() // 캡슐 이동 함수
    {
        float posX = Random.Range(-40f, 40f);
        float posZ = Random.Range(-40f, 40f); // 이동할 곳 Random으로 추출

        _capsulePos.position = new Vector3(posX, 0f, posZ); // Random한 위치
        
        if (Vector3.Distance(transform.position, _playerPos.position) < 3f) // 만약에 랜덤한 위치가 플레이어의 위치와의 거리가 3 보다 작다면
        {
            float rePosX = Random.Range(-40f, 40f);
            float rePosZ = Random.Range(-40f, 40f);
            _capsulePos.position = new Vector3(rePosX, 0f, rePosZ); // Random 다시 추출
        }

        _animator.SetTrigger("Jump"); // 점프하는 애니메이션 실행

        _isMovingOnOff._isMove = false; // 이동 중이냐를 false로
    }

    //private void OnDestroy()
    //{
        
    //    _gamemanager.delaytime -= -0.4f;
    //    _gamemanager.rebrith(gameObject);

    //}


}
