using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCasting : MonoBehaviour {

    public Transform _playerPos; // 플레이어 위치
    public Animator _animator; // 플레이어 애니메이터
    public Transform _firePos; // 발사 위치
    public GameObject _magic; // 발사 마법
    public MeshRenderer[] _casting; // 캡슐이 캐스팅하면 머리 위에 변하는 구슬
    public Material[] _castingMaterial; // 구슬 매터리얼 0과 1
    public float _castingDelayTime; // 캐스팅 하는데 걸리는 시간
    public CapsuleFSM _isCastingOnOff; // FSM에 있는 캐스팅 중이냐 아니냐
    int _castingNum = 0; // 캐스팅 할 때 마다 1 증가

    public void LookCastingFire() // FSM에서 상태가 CASTING이 되면 실행
    {
        if (!_isCastingOnOff._isCasting) // 캐스팅 중이 아닐 경우
        {
            _isCastingOnOff._isCasting = true; // 캐스팅 중으로
            StartCoroutine(MoveAndLookCoroutine()); // 쳐다보는 코루틴 실행
        }
    }

    private IEnumerator MoveAndLookCoroutine() // 쳐다보는 코루틴
    {
        yield return new WaitForSeconds(1f); // 1초 대기 후

        // 그냥 LookAt 쓰면 할배 자꾸 누워서 수정
        Vector3 targetPostition = new Vector3(_playerPos.position.x, this.transform.position.y, _playerPos.position.z);
        this.transform.LookAt(targetPostition); // 쳐다 봄
        
        CastingOn(); // 캐스팅 실행
    }

    public void CastingOn()
    {
        if (_castingNum == 3) // 캐스팅을 3번 했다면
        {
            StartCoroutine(FireCoroutine()); // 발사 코루틴 실행
            _castingNum = 0; // 캐스팅 숫자 0으로 다시 초기화
        }
        else // 캐스팅을 3번 하지 않았다면
        {
            _casting[_castingNum].material = _castingMaterial[1]; // 순서대로 캡슐 머리 위의 구슬의 매터리얼을 바꿈
            _castingNum++; // 캐스팅 숫자 1 증가

            _isCastingOnOff._isCasting = false; // 캐스팅 중을 아닌 것으로
        }
    }

    private IEnumerator FireCoroutine() // 발사 코루틴
    {
        yield return new WaitForSeconds(1f); // 1초 대기 후

        Vector3 targetPostition = new Vector3(_playerPos.position.x, this.transform.position.y, _playerPos.position.z);
        this.transform.LookAt(targetPostition); // 플레이어를 쳐다 봄

        _animator.SetTrigger("Fire"); // 스태프 휘두르는 애니메이션 실행
        Instantiate(_magic, _firePos.position, _firePos.rotation); // 마법 발싸!!
        Debug.Log("Fire!!");

        _casting[0].material = _castingMaterial[0];
        _casting[1].material = _castingMaterial[0];
        _casting[2].material = _castingMaterial[0]; // 머리 위의 구슬을 원래대로 바꿈

        _isCastingOnOff._isCasting = false; // 캐스팅 중이냐를 아니오로
    }
}
