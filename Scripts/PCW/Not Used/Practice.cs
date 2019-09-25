using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice : MonoBehaviour {

    public GameObject _player;
    public Transform _playerPos;
    public MeshRenderer[] _casting;
    public Material[] _castingMaterial;
    public float _castingDelayTime;
    public CapsuleFSM _isCastingOnOff;
    int _castingNum;

    void Start()
    {

    }

    void Update()
    {

    }


    public void LookCastingFire()
    {
        if (!_isCastingOnOff._isCasting)
        {
            _isCastingOnOff._isCasting = true;
            StartCoroutine(MoveAndLookCoroutine());
        }
    }

    private IEnumerator MoveAndLookCoroutine()
    {
        yield return new WaitForSeconds(1f);

        transform.LookAt(_player.transform.position);

        CastingOn(_castingNum);
    }

    public void CastingOn(int i)
    {
        _casting[0].material = _castingMaterial[1];
        _casting[1].material = _castingMaterial[1];
        _casting[2].material = _castingMaterial[1];

        if (_casting[2].material = _castingMaterial[1])
        {
            StartCoroutine(FireCoroutine());
            _castingNum = 0;
        }
    }

    private IEnumerator FireCoroutine()
    {
        yield return new WaitForSeconds(1f);

        Debug.Log("Fire!!");

        _casting[0].material = _castingMaterial[0];
        _casting[1].material = _castingMaterial[0];
        _casting[2].material = _castingMaterial[0];

        _isCastingOnOff._isCasting = false;
    }

}
