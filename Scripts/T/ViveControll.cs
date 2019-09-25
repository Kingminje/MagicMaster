using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.Pointer3D;

public class ViveControll : MonoBehaviour {

    //public Pointer3DRaycaster raycaster;
    public Mj_MagicBook _magicbook;
    public Transform _tr_rightcontroller;
    public LBJ_CGameManager _gameManager;

    // Update is called once per frame
    void Update () {

        if (ViveInput.GetPressDownEx(HandRole.RightHand, ControllerButton.Trigger) && !LBJ_CGameManager.KeyCodeTrigger && _gameManager.Fire)
        {
            //Debug.Log("Right Hand Trigger Button!!");

            _gameManager._runeButton[_gameManager.index[0]].color = new Color(_gameManager._runeButton[_gameManager.index[0]].color.r, _gameManager._runeButton[_gameManager.index[0]].color.g, _gameManager._runeButton[_gameManager.index[0]].color.b, 0);

            _gameManager.i = 0;
            _gameManager.Fire = false;

            _magicbook.MagicToRow(_gameManager.index[0],_tr_rightcontroller);
            
        }
        
        // 터치 패드 디렉션
        Vector2 direction = ViveInput.GetPadPressAxisEx(HandRole.RightHand);
        if (direction != Vector2.zero)
        {
            //Debug.Log("Pad Press Axis => " + direction);
            
            if (direction.x > 0f && direction.y < 0.5f && direction.y > -0.5f)
            {
                _gameManager.vivebuttonright();
                //_gameManager.RuneKeyCodeButtonDown(3);
                //return SwipeDirection.RIGHT;
            }
            else if (direction.x < 0f && direction.y < 0.5f && direction.y > -0.5f)
            {
                _gameManager.vivebuttonleft();
                //_gameManager.RuneKeyCodeButtonDown(1);
                //return SwipeDirection.LEFT;
            }
            else if (direction.y > 0f && direction.x < 0.5f && direction.x > -0.5f)
            {
                _gameManager.vivebuttonup();
                //_gameManager.RuneKeyCodeButtonDown(0);
                //return SwipeDirection.UP;
            }
            else if (direction.y < 0f && direction.x < 0.5f && direction.x > -0.5f)
            {
                _gameManager.vivebuttondown();
                //_gameManager.RuneKeyCodeButtonDown(2);
                //return SwipeDirection.DOWN;
            }
        }

    }
}
