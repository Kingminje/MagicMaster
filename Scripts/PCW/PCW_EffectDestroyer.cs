using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCW_EffectDestroyer : MonoBehaviour {

    private ParticleSystem _particleSys;

    private void Start()
    {
        // 컴포넌트타입 참조변수 = GetComponentInChildren<컴포넌트타입>();
        // -> 자식 오브젝트들을 순회하면서 해당 컴포넌트와 일치하는 컴포넌트를 찾아 참조함
        _particleSys = GetComponentInChildren<ParticleSystem>();

        // 이펙트 재생이 끝나면 이펙트를 파괴함
        Destroy(gameObject, _particleSys.main.duration);
    }
}
