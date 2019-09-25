using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mj_GearVRRaycastController : MonoBehaviour {

    // 메인 카메라 참조
    public Transform m_Camera;

    // 레이 체크에서 제외될 레이어
    public LayerMask m_ExclusionLayers;

    // 기본 레이 길이
    public float m_RayLength = 500f;

    // 리티클
    //public Reticle m_Reticle;

    // 라인 렌더러 참조
    public LineRenderer m_LineRenderer = null;

    // 라인 렌더러 표시 여부
    public bool ShowLineRenderer = true;

    // 트랙 스페이스 참조
    public Transform m_TrackingSpace = null;

    public Ray _ray;

    public RaycastHit _hit;

    // VR 입력(고급)
    public Mj_GearVRInputAdvance m_VrInput;

    public void ControllerRayCast()
    {

        // 카메라 시선에 맞는 레이를 수행함
        Ray ray = new Ray(m_Camera.position, m_Camera.forward);   

        _ray = ray;

        // 컨트롤러가 존재하고 라인렌더러가 참조되어 있다면
        Vector3 worldStartPoint = Vector3.zero;
        Vector3 worldEndPoint = Vector3.zero;

        // 라인렌더러가 존재한다면
        if (m_LineRenderer != null)
        {
            // 리모트 컨트롤러가 연결되어 있고 라인렌더러가 참조 되어있고
            m_LineRenderer.enabled = m_VrInput.ControllerIsConnected && ShowLineRenderer;
        }

        // 컨트롤러가 연결되어 있고 트래킹 영역이 존재한다면
        if (m_VrInput.ControllerIsConnected && m_TrackingSpace != null)
        {
            // 컨트롤러의 회전을 구하고
            Matrix4x4 localToWorld = m_TrackingSpace.localToWorldMatrix;
            //Quaternion orientation = m_Camera.localRotation;
            Quaternion orientation = OVRInput.GetLocalControllerRotation(m_VrInput.Controller);

            // 컨트롤러의 레이 시작 위치와 끝 위치를 정함
            //Vector3 localStartPoint = m_Camera.localPosition;
            Vector3 localStartPoint = OVRInput.GetLocalControllerPosition(m_VrInput.Controller);
            Vector3 localEndPoint = localStartPoint + ((orientation * Vector3.forward) * 500f);

            // 로컬 위치를 월드 위치로 변경하고
            worldStartPoint = localToWorld.MultiplyPoint(localStartPoint);
            worldEndPoint = localToWorld.MultiplyPoint(localEndPoint);

            // 레이를 변경함
            ray = new Ray(worldStartPoint, worldEndPoint - worldStartPoint);
        }

        

        // 리모트 컨트롤러가 연결되어 있고 라인렌더러가 존재한다면
        if (m_VrInput.ControllerIsConnected && m_LineRenderer != null)
        {
            // 라인렌더러를 그려줌
            m_LineRenderer.SetPosition(0, worldStartPoint);
            m_LineRenderer.SetPosition(1, worldEndPoint);
        }
    }

    

    private void Update()
    {
        ControllerRayCast();
    }
}
