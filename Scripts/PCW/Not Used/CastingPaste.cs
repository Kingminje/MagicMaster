using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingPaste : MonoBehaviour {

    public GameObject _player;
    public Transform _playerPos;
    public MeshRenderer[] _casting;
    public Material[] _castingMaterial;
    public float _castingDelayTime;
    public CapsuleFSM _isCastingOnOff;

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

        StartCoroutine(CastingOnCoroutine());
    }

    private IEnumerator CastingOnCoroutine()
    {
        for (int i = 0; i <= 2; i++)
        {
            yield return new WaitForSeconds(_castingDelayTime);

            _casting[i].material = _castingMaterial[1];
        }

        StartCoroutine(FireCoroutine());

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
