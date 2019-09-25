using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateMovement : MonoBehaviour {

    public Transform _playerPos;
    public LayerMask _layer;
    public LayerMask _dontlayer;
    private Vector3 _destination = new Vector3(0, 0, 0);
    public float _maxMoveDist;
    public GameObject _speedParticle;
    public bool _isMoving = false; // 이동 쿨타임을 위한 bool 타입

    public Mj_GearVRRaycastController _gearVRRaycastController;

    void Start () {
        Vector3 _playerPos = gameObject.GetComponent<Transform>().position;
	}

    void Update()
    {
        RaycastHit _hit = new RaycastHit();

        //화면을 클릭 하면 땅바닥 좌표 저장
        if (LBJ_CGameManager.KeyCodeTrigger == true) return;
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
            }
        }

        if (Vector3.Distance(transform.position, _destination) == 0.0f)
        {
            return;
        }

        _playerPos.position = _destination;
       _playerPos.position = new Vector3(_playerPos.position.x, 2.6f, _playerPos.position.z);
        
        // transform.LookAt(_target.transform.position);
        // if문 지우고 Move() 바로 실행
    }

    private IEnumerator SpeedParticleCoroutine()
    {
        _speedParticle.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        _speedParticle.SetActive(false);
    }

    //private void Move()
    //{
    //    if (Vector3.Distance(transform.position, _destination) == 0.0f)
    //    {
    //        _isMove = false;
    //        return;
    //    }

    //    _playerPos.position = _destination;
    //    _playerPos.position = new Vector3(_playerPos.position.x, 1f, _playerPos.position.z);

    //}
}
