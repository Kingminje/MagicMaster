using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleClcikMovement : MonoBehaviour
{

    public GameObject _player;
    public Transform _playerPos;
    public Transform _capsulePos;
    private bool _isCapsuleMove = false;
    private Vector3 _destination = new Vector3(0, 0, 0);

    void Start()
    {
        Vector3 _capsulePos = gameObject.GetComponent<Transform>().position;
        _isCapsuleMove = false;
    }

    void Update()
    {
        transform.LookAt(_player.transform.position);

        //if (GameObject.Find("Player").GetComponent<TranslateMovement>()._isMove)
        //{
        //    _isCapsuleMove = true;
        //}

        if (_isCapsuleMove)
        {
            CapsuleMove();
        }
    }

    private void CapsuleMove()
    {
        if (Vector3.Distance(transform.position, _destination) == 0.0f)
        {
            _isCapsuleMove = false;
            return;
        }
        float posX = Random.Range(-10f, 10f);
        float posZ = Random.Range(-10f, 10f);

        _capsulePos.position = _destination;
        _capsulePos.position = new Vector3(posX, 1f, posZ);

        if (Vector3.Distance(transform.position, _playerPos.position) < 3f)
        {
            CapsuleMove();
        }

        //GameObject.Find("Player").GetComponent<TranslateMovement>()._isMove = false;
        _isCapsuleMove = false;
    }
}
