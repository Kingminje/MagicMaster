using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PCW_StartScenePvPButton : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene("photonTest");

        PCW_PlayerState._isDie = false;
    }

}
