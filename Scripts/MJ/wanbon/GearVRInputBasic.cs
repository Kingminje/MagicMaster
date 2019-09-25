using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearVRInputBasic : MonoBehaviour
{
    public enum SwipeDirection
    {
        UP , LEFT, DOWN, RIGHT, TAP, NONE
    }

    //public Material[] m_mats;

    private Vector2 m_InputStart;
    private Vector2 m_InputEnd;

    //public Renderer m_Renderer;

    public CGameManager m_gamemanager;

    private void Update()
    {
        SwipeDirection sd = DetectSwipe();
        //if (sd != SwipeDirection.NONE && !m_gamemanager.GameManagerTrigger)
        {
            // 선택된 제스쳐에 맞는 매터리얼을 적용함
            //m_Renderer.material = m_mats[(int)sd];            
            //m_gamemanager.InputButton((int)sd); // 사용시 주석 파괴해
        }
    }

    private SwipeDirection DetectSwipe()
    {
        // 화면에 마우스 왼쪽 버튼을 클릭했다면
        // -> GearVR 터치 패드에 터치 다운 했다면
        if (Input.GetMouseButtonDown(0))
        {
            // 현재 터치 다운 좌표를 저장함
            m_InputStart = Input.mousePosition;
        }
        // 화면에 마우스 왼쪽 버튼을 클릭했다면
        // -> GearVR 터치 패드에 터치 업 했다면
        if (Input.GetMouseButtonUp(0))
        {
            // 현재 터치 업 좌표를 저장함
            m_InputEnd = Input.mousePosition;

            // 제스쳐 벡터를 정규화함
            // -> GearVR의 터치 영역은 -1 ~ 0 ~ 1
            Vector2 currentInput = (m_InputEnd - m_InputStart).normalized;

            // 오른쪽 방향으로 제스쳐를 했다면
            if (currentInput.x > 0f &&
                currentInput.y < 0.5f && currentInput.y > -0.5f)
            {
                return SwipeDirection.RIGHT;
            }
            // 왼쪽 방향으로 제스쳐를 했다면
            else if (currentInput.x < 0f &&
                     currentInput.y < 0.5f && currentInput.y > -0.5f)
            {
                return SwipeDirection.LEFT;
            }
            // 위쪽 방향으로 제스쳐를 했다면
            else if (currentInput.y > 0f &&
                currentInput.x < 0.5f && currentInput.x > -0.5f)
            {
                return SwipeDirection.UP;
            }
            // 아래쪽 방향으로 제스쳐를 했다면
            else if (currentInput.y < 0f &&
                     currentInput.x < 0.5f && currentInput.x > -0.5f)
            {
                return SwipeDirection.DOWN;
            }

            // 탭
            return SwipeDirection.TAP;
        }

        return SwipeDirection.NONE;
    }
}
