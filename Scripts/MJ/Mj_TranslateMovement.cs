using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mj_TranslateMovement : Photon.MonoBehaviour
{

    public Transform _playerPos;
    public LayerMask _layer;
    public LayerMask _dontlayer;
    private Vector3 _destination = new Vector3(0, 0, 0);
    public float _maxMoveDist;
    public GameObject _speedParticle;
    public bool _moveCoolOn = false; // 이동 쿨타임을 위한 bool 타입
    public Image _moveCoolTimeImage; // 텔포 쿨타임 이미지

    public Mj_GearVRRaycastController _gearVRRaycastController;

    private Vector3 _randomValue;

    private void Start()
    {
        if (photonView.isMine)
        {
            float PosX = Random.Range(-40f, 40f);
            float PosZ = Random.Range(-40f, 40f);
            _randomValue = new Vector3(PosX, 2.6f, PosZ);
            _destination = _randomValue;
            Vector3 _playerPos = gameObject.GetComponent<Transform>().position;
        }
        
    }

    void Update()
    {
        RaycastHit _hit = new RaycastHit();
        if (photonView.isMine)
        {
            // 화면을 클릭 하면 땅바닥 좌표 저장
            if (LBJ_CGameManager.KeyCodeTrigger == false && _moveCoolOn == false)
            {
                if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.JoystickButton5) || OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
                {
                    Ray ray = _gearVRRaycastController._ray;

                    if (Physics.Raycast(ray, out _hit, _maxMoveDist, _dontlayer))
                    {
                        return;
                    }

                    if (Physics.Raycast(ray, out _hit, _maxMoveDist, _layer))
                    {
                        _destination = _hit.point;
                        StartCoroutine(SpeedParticleCoroutine());
                        StartCoroutine(MoveImageCoolTimeCoroutine()); // 쿨타임 이미지를 띄우고 쿨타임 기간 동안 돌도록
                    }
                }

                if (Vector3.Distance(transform.position, _destination) == 0.0f)
                {
                    return;
                }

                _playerPos.position = _destination;
                _playerPos.position = new Vector3(_playerPos.position.x, 2.6f, _playerPos.position.z); // 이게 없으면 땅 위가 아닌 공중으로 날아감 y값 고정

            }
        }
        
    }

    private IEnumerator SpeedParticleCoroutine()
    {
        _speedParticle.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        _speedParticle.SetActive(false);
    }

    //private IEnumerator MoveCoolTimeCoroutine()
    //{
    //    _moveCoolOn = true;
    //    yield return new WaitForSeconds(0.5f);
    //    _moveCoolOn = false;
    //}

    private IEnumerator MoveImageCoolTimeCoroutine() // 쿨타임 이미지를 띄우고 쿨타임 기간(0.5초) 동안 돌도록 하는 코루틴
    {
        _moveCoolOn = true;

        float moveCoolTime = 0.5f;

        float waitTime = 0.5f;

        _moveCoolTimeImage.color = new Color(_moveCoolTimeImage.color.r, _moveCoolTimeImage.color.g, _moveCoolTimeImage.color.b, 1f);

        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;

            if (waitTime < 0)
            {
                waitTime = 0;
            }

            float filling = 1 - (waitTime / moveCoolTime);

            _moveCoolTimeImage.fillAmount = filling;

            yield return new WaitForSeconds(0.001f);

        }

        _moveCoolOn = false;
    }
}