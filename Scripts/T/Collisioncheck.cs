using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisioncheck : MonoBehaviour {

    public SphereCollider _coolision;

    public int _magicDamagePoint;

	// Use this for initialization
	void Start () {
        StartCoroutine(collisionstart());		
	}

    IEnumerator collisionstart()
    {
        yield return new WaitForSeconds(0.1f);
        _coolision.enabled = true;
    }
	

}
