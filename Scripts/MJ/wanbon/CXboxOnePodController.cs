using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CXboxOnePodController : MonoBehaviour {

    private CGameManager _gameManager;

    

    // Update is called once per frame
    void Update () {
        InputButton();
    }

    private void InputButton()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Debug.Log("A버튼 입력");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            Debug.Log("B버튼 입력");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            Debug.Log("X버튼 입력");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            Debug.Log("Y버튼 입력");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            Debug.Log("X-Axis버튼 입력");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            Debug.Log("Y-Axis버튼 입력");
        }

    }
}
