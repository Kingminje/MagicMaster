using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEnd : MonoBehaviour {
    
    public void onClickRestart()
    {
        SceneManager.LoadScene("ViveStandalone");
    }

}
