using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public Image _hpProgress; // HpProgress 이미지 참조
    public Animator _anim; // 애니메이터 참조
    public int _enemyHP; // 적 체력

    private void OnCollisionEnter(Collision collision) // 콜라이더 부딪히면
    {
        if (collision.gameObject.tag == "Magic") // 부딪히는 게임오브젝트의 태그가 Magic이라면
        {
            Debug.Log("피격");

            Destroy(collision.gameObject);
            _enemyHP = HpDown(50); // HpDown 실행
            if (_enemyHP <= 0) // 만약에 HP가 0보다 작아진다면
            {
                StartCoroutine(DieAnimAndDestroy()); // 애니메이션 재생 후 삭제하는 코루틴 실행
            }
        }
    }

    public int HpDown(int damage)
    {
        _hpProgress.fillAmount -= (damage * 0.01f);
        return (int)(_hpProgress.fillAmount * _enemyHP);
    }

    private IEnumerator DieAnimAndDestroy()
    {
        _anim.SetTrigger("Death");

        yield return new WaitForSeconds(4f);

        Destroy(gameObject);
    }
}

