using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleFSM : MonoBehaviour
{

    public enum STATE
    {
        IDLE, // 대기
        MOVE, // 이동
        // LOOK, // 바라보기
        CASTING, // 캐스팅
        // FIRE, // 마법 발사
        // HIT, // 피격
        DEATH // 사망
    }

    public STATE _state = STATE.IDLE;

    public Transform _targetTr;

    public CapsuleMovement _movement;

    public CapsuleCasting _casting;

    public Animator _animator;

    public EnemyHealth enemyHealth;

    public bool _isCasting = false;
    public bool _isMove = false;

    public float _castingDist = 7f;

    public float _traceDist = 15f;

    void Start()
    {
        _targetTr = GameObject.FindWithTag("Player").transform;

        StartCoroutine(CapsuleStateCheckCoroutine());
        StartCoroutine(CapsuleStateActionCoroutine());
    }

    public IEnumerator CapsuleStateCheckCoroutine()
    {
        while (_state != STATE.DEATH)
        {
            if (PlayerState._isDie)
            {
                _state = STATE.DEATH;    // 대기 상태로 변경
                yield return null;
                continue;
            }

            // float 두 위치간의 거리 = Vector3.Distance(위치, 위치);
            float dist = Vector3.Distance(_targetTr.position, transform.position);

            int attackPercent = Random.Range(0, 10);
            // Debug.Log(attackPercent);

            if (dist <= _traceDist)
            {
                _state = STATE.MOVE;
                if (dist <= _castingDist)
                {
                    if (attackPercent > 7)
                    {
                        _state = STATE.MOVE;
                        //Debug.Log("확률로 이동 체크");
                    }
                    else
                    {
                        _state = STATE.CASTING;
                        //Debug.Log("확률로 공격 체크");
                    }
                }
            }
            else
            {
                _state = STATE.MOVE;    // 대기 상태로 변경
            }

            if (enemyHealth._enemyHP <= 0)
            {
                _state = STATE.DEATH;   // 죽음 상태로 변경
            }

            yield return new WaitForSeconds(_movement._moveDealayTime);
        }
    }

    private IEnumerator CapsuleStateActionCoroutine()
    {
        while (_state != STATE.DEATH)
        {
            switch (_state)
            {
                case STATE.IDLE:
                    _isMove = false;   // 이동 정지
                    break;

                case STATE.MOVE:
                    _isMove = true;    // 추적 이동
                    _movement.CapsuleMove();
                    _state = STATE.IDLE;
                    //Debug.Log("이동 실행");
                    break;

                case STATE.CASTING:
                    _isMove = false;
                    _casting.LookCastingFire();
                    _state = STATE.IDLE;
                    //Debug.Log("캐스팅 실행");
                    break;

                case STATE.DEATH:
                    _isMove = false;
                    //Debug.Log("으앙 쥬금");
                    break;
            }
            
            yield return null;
        }
    }
}