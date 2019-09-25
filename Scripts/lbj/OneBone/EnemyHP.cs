using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour {

    public Image _hpProgress;


    //피격시 받은 int값으로 hp 바 조정. // 3.26 기준 비사용.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Magic")
        {
            Debug.Log("피격");
            int hp = HpDown(50);
            if (hp <= 0)
            {
                Destroy(gameObject);
            }

        }
    }

    public int HpDown(int damage)
    {
        _hpProgress.fillAmount -= (damage * 0.01f);
         return (int)(_hpProgress.fillAmount * 100f);
    }
}
