using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CTargetAngleUI : MonoBehaviour {

    public Transform _moveTargetTr;
    public Image _trRight;
    public Image _trLeft;

    public void Update()
    {
        if (_moveTargetTr == null)
        {
            _trRight.color = new Color(255f, 255f, 255f, 0f);
            _trLeft.color = new Color(255f, 255f, 255f, 0f);
        }

        else
        {
            TrFind();
        }
    }

    //화살표 UI 타겟 위치 판별 
    // 카메라 시점과 타겟 위치 파악
    //  transform.InverseTransformPoint
    //  https://docs.unity3d.com/ScriptReference/Transform.InverseTransformPoint.html

    public void TrFind()
    {
        Vector3 v3RelativePoint = transform.InverseTransformPoint(_moveTargetTr.position);


        if (v3RelativePoint.x > 2f)
        {
            _trRight.color = new Color(255f, 0, 0);
            _trLeft.color = new Color(255f, 255f, 255f, 0f);

        }
        else if (v3RelativePoint.x < -2f)
        {
            _trLeft.color = new Color(255f, 0, 0);
            _trRight.color = new Color(255f, 255f, 255f, 0f);

        }
        else
        {
            if (v3RelativePoint.z < 0)
            {
                return;
            }

            _trRight.color = new Color(255f, 255f, 255f, 0f);
            _trLeft.color = new Color(255f, 255f, 255f, 0f);

        }
    }
}
