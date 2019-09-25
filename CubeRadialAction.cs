using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInputAction : MonoBehaviour
{
    public GearVRInputAdvance m_VrInput;    // 기어 VR 입력 참조
    //public VRInteractiveItem m_InteractiveItem; // VR 상호 작용 아이템
    //public Material[] m_Mats;   // 큐브 색상 메터리얼
    //public Renderer m_Renderer; // 큐브 렌더러
    public CGameManager m_CameManager;

    //private void OnEnable()
    //{
    //    m_VrInput.OnTriggerButtonDown += OnTriggerButtonDown;
    //    m_VrInput.OnTouchPadDown += OnTouchPadDown;
    //    m_VrInput.OnTouchPadUp += OnTouchPadUp;

    //    m_VrInput.OnTouchPadTapRight += OnTouchPadTapRight;
    //    m_VrInput.OnTouchPadTapLeft += OnTouchPadTapLeft;
    //    m_VrInput.OnTouchPadTapUp += OnTouchPadTapUp;
    //    m_VrInput.OnTouchPadTapDown += OnTouchPadTapDown;
    //    m_VrInput.OnTouchPadTap += OnTouchPadTap;
    //}

    //private void OnDisable()
    //{
    //    m_VrInput.OnTriggerButtonDown -= OnTriggerButtonDown;
    //    m_VrInput.OnTouchPadDown -= OnTouchPadDown;
    //    m_VrInput.OnTouchPadUp -= OnTouchPadUp;

    //    m_VrInput.OnTouchPadTapRight -= OnTouchPadTapRight;
    //    m_VrInput.OnTouchPadTapLeft -= OnTouchPadTapLeft;
    //    m_VrInput.OnTouchPadTapUp -= OnTouchPadTapUp;
    //    m_VrInput.OnTouchPadTapDown -= OnTouchPadTapDown;
    //    m_VrInput.OnTouchPadTap -= OnTouchPadTap;
    //}

    private void OnTriggerButtonDown()
    {
        //if (m_InteractiveItem.IsOver)
        //{
        //    m_Renderer.material = m_Mats[(int)GearVRInputAdvance.CONTROLL_TYPE.TRIGGER];
        //}

    }

    private void OnTouchPadDown()
    {
        //if (m_InteractiveItem.IsOver)
        //{
        //    m_Renderer.material = m_Mats[(int)GearVRInputAdvance.CONTROLL_TYPE.TOUCH_DOWN];
        //}
    }

    private void OnTouchPadUp()
    {
        //if (m_InteractiveItem.IsOver)
        //{
        //    m_Renderer.material = m_Mats[(int)GearVRInputAdvance.CONTROLL_TYPE.TOUCH_UP];
        //}
        //else
        //{
        //    m_Renderer.material = m_Mats[(int)GearVRInputAdvance.CONTROLL_TYPE.NONE];
        //}
    }

    private void OnTouchPadTapRight()
    {
        //m_Renderer.material = m_Mats[(int)GearVRInputAdvance.CONTROLL_TYPE.RIGHT];
    }

    private void OnTouchPadTapLeft()
    {
        //m_Renderer.material = m_Mats[(int)GearVRInputAdvance.CONTROLL_TYPE.LEFT];
    }

    private void OnTouchPadTapUp()
    {
        //m_Renderer.material = m_Mats[(int)GearVRInputAdvance.CONTROLL_TYPE.UP];
    }

    private void OnTouchPadTapDown()
    {
        //m_Renderer.material = m_Mats[(int)GearVRInputAdvance.CONTROLL_TYPE.DOWN];
    }

    private void OnTouchPadTap()
    {
        //if (m_InteractiveItem.IsOver)
        //{
        //    m_Renderer.material = m_Mats[(int)GearVRInputAdvance.CONTROLL_TYPE.TAP];
        //}
    }
}