using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickEffect : MonoBehaviour {

    public GameObject _buttonEffectPrefab;
    public Transform[] _buttonTr;

	public void OnButtonClickEffect(int i)
    {
        Vector3 buttonPos = new Vector3(_buttonTr[i].transform.position.x, _buttonTr[i].transform.position.y, _buttonTr[i].transform.position.z);

        Instantiate(_buttonEffectPrefab, buttonPos, Quaternion.identity);
    }

}
