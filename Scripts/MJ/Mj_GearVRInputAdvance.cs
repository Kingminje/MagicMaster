using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mj_GearVRInputAdvance : MonoBehaviour {
    
    public enum CONTROLL_TYPE
    {
        TAP, UP, DOWN, LEFT, RIGHT, NONE, TRIGGER, TOUCH_DOWN
    }

    private Vector2 m_TouchPosition;

    public Action OnTriggerButtonDown;
    public Action OnTouchPadDown;
    public Action OnTriggerTouchPadUp;
    public Action OnTouchPadTapRight;
    public Action OnTouchPadTapLeft;
    public Action OnTouchPadTapUp;
    public Action OnTouchPadTapDown;
    public Action OnTouchPadTap;

    // 리모트 컨트롤러 연결 여부 프로퍼티
    public bool ControllerIsConnected
    {
        get
        {
            // 왼쪽 또는 오른쪽 컨트롤러가 존재하고 연결되어 있다면 True 리턴
            OVRInput.Controller controller = OVRInput.GetConnectedControllers() & (OVRInput.Controller.LTrackedRemote | OVRInput.Controller.RTrackedRemote);

            return controller == OVRInput.Controller.LTrackedRemote ||
                controller == OVRInput.Controller.RTrackedRemote;
        }
    }

    // 리모트 컨트롤러 프로퍼티
    public OVRInput.Controller Controller
    {
        get
        {
            // 현재 왼쪽 손에 컨트롤러가 있다면 왼쪽 컨트롤러를,
            // 아니면 오른쪽 컨트롤러를,
            // 아니면 활성 컨트롤러를 리턴함
            OVRInput.Controller controller = OVRInput.GetConnectedControllers();

            if ((controller & OVRInput.Controller.LTrackedRemote) == OVRInput.Controller.LTrackedRemote)
            {
                return OVRInput.Controller.LTrackedRemote;
            }
            else if ((controller & OVRInput.Controller.RTrackedRemote) == OVRInput.Controller.RTrackedRemote)
            {
                return OVRInput.Controller.RTrackedRemote;
            }

            return OVRInput.GetActiveController();
        }
    }
   
}
