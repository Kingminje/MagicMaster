using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    public Transform _playerPos;
    // public float velocity = 1.0f;
    public LayerMask layer;
    private CharacterController _controller;
    private bool _isMove = false;
    private Vector3 _destination = new Vector3(0, 0, 0);
    public float _maxMoveDist;

    void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
        _isMove = false;
    }

    void Update()
    {

        RaycastHit _hit = new RaycastHit();

        //화면을 클릭 하면 땅바닥 좌표 저장. 
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hit, _maxMoveDist, layer))
            {
                _destination = _hit.point;
                _isMove = true;
            }
        }

        //땅바닥 좌표가 플레이어와 다르면 움직인다. 
        if (_isMove)
        {
            Move();
        }
    }

    //움직이는 함수 
    private void Move()
    {
        //목적지와 거리가 같으면 안 움직임 
        if (Vector3.Distance(transform.position, _destination) == 0.0f)
        {
            _isMove = false;
            return;
        }

        Vector3 direction = _destination - transform.position;
        direction = Vector3.Normalize(direction);

        _controller.Move(direction);
    }
}
