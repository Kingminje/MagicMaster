using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VivePlayerHP : MonoBehaviour
{

    public Image _hpProgress;
    public int _playerHp;
    public GameObject _playerprefabs;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Magic")
        {
            int point = collision.gameObject.GetComponent<Collisioncheck>()._magicDamagePoint;

            Destroy(collision.gameObject);

            _playerHp = HpDown(point);

            if (_playerHp <= 0)
            {
                StartCoroutine(DieAnimAndDestroy());
            }
        }
    }

    public int HpDown(int damage)
    {
        _hpProgress.fillAmount -= (damage * 0.01f);
        return (int)(_hpProgress.fillAmount * 100f);
    }

    private IEnumerator DieAnimAndDestroy()
    {

        PCW_PlayerState._isDie = true;
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("End"); // End씬 이동

      
        //rebreath();
        
        
    }

    //public void rebreath()
    //{
    //    Instantiate(_playerprefabs, transform.position, transform.rotation);
    //    Destroy(gameObject);
    //}
}
