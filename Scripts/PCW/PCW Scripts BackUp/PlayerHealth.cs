using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public Image _hpProgress;
    public int _playerHp;
    public Animator _anim; // 애니메이터 참조
    public GameObject _playerCharacter; // 플레이어 캐릭터 참조 - 위자드 연결
    public GameObject _staff; // 스태프 참조 (데스캠에서 스태프가 혼자 떠 있음)
    public GameObject _liveLeftCam; // 기존 카메라(좌측 눈) 참조
    public GameObject _liveCenterCam;
    public GameObject _liveRightCam;
    public GameObject _deathCam; // 데스캠 참조 OVRDeathCameraRig 연결
    //public CameraShake _cameraShake; // 세이크 카메라 참조

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Magic")
        {
            Debug.Log("피격");

            Destroy(collision.gameObject);
            
            _playerHp = HpDown(50);

            Debug.Log(_playerHp);
            //_cameraShake.ShakeCamera(10f, 1f); // 데미지 판정 받을 시 세이크 카메라 기능 작동.
            if (_playerHp <= 0)
            {
                StartCoroutine(DieAnimAndDestroy());
            }
        }
    }

    public int HpDown(int damage)
    {
        _hpProgress.fillAmount -= (damage * 0.01f);
        return (int)(_hpProgress.fillAmount * _playerHp);
    }

    private IEnumerator DieAnimAndDestroy()
    {
        _anim.SetTrigger("Death"); // Death 애니메이션 재생

        PlayerState._isDie = true;

        _playerCharacter.layer = 0; // 플레이어 캐릭터의 Death 애니메이션을 볼 수 있도록 레이어를 0. Default로 변경함

        Destroy(_staff); // 스태프 삭제
        
        DestroyImmediate(_liveLeftCam); // 라이브캠 삭제
        DestroyImmediate(_liveCenterCam);
        DestroyImmediate(_liveRightCam);

        _deathCam.SetActive(true); // 데스캠 활성화

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("End"); // End씬 이동

    }
}
