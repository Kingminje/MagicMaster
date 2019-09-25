using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PCW_EndSceneMainMenuButton : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene("Start");

        PCW_PlayerState._isDie = false;
    }
}
