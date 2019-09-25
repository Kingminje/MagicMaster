using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour {

	public void OnTutorialButtonClick()
    {
        SceneManager.LoadScene("project");
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("photonTest");
    }
}
