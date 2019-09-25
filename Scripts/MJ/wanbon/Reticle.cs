using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
    // 카메라 시작지점과 리티클 간의 기본 거리
    public float m_DefaultDistance;

    // 리티클 위치
    public Transform m_ReticleTransform;

    // 카메라 참조
    public Transform m_Camera;

    // 리티클 기본 스케일
    public Vector3 m_OriginalScale;

    // 리티클 회전
    public Quaternion m_OriginalRotation;

    private void Awake()
    {
        m_OriginalScale = m_ReticleTransform.localScale;
        m_OriginalRotation = m_ReticleTransform.rotation;
    }

    /// <summary>
    /// 리티클 기본 위치 표시
    /// </summary>
    public void SetPosition()
    {
        // 리티클의 위치를 카메라의 시선에 기본 거리로 유지해서 표시함
        m_ReticleTransform.position = m_Camera.position + m_Camera.forward * m_DefaultDistance;

        // 리티클의 스케일을 카메라와의 기본 거리에 맞게 스케일링함
        m_ReticleTransform.localScale = m_OriginalScale * m_DefaultDistance;

        // 리티클의 회전을 원본 회전값을 적용함
        m_ReticleTransform.localRotation = m_OriginalRotation;
    }

    /// <summary>
    /// 리티클을 충돌 위치점에 표시
    /// </summary>
    public void SetPosition(RaycastHit hit)
    {
        // 리티클의 위치를 충돌 지점에 표시함
        m_ReticleTransform.position = hit.point;

        // 리티클의 스케일을 충돌 지점을 기준으로 설정함
        m_ReticleTransform.localScale = m_OriginalScale * hit.distance;

        // 리티클의 회전을 원본 회전값을 적용함
        m_ReticleTransform.localRotation = m_OriginalRotation;
    }

    /// <summary>
    /// 위치와 방향에 맞는 리티클 위치를 설정함
    /// </summary>
    public void SetPosition(Vector3 position, Vector3 forward)
    {
        // 리티클의 위치를 충돌체 방향에 기본 거리를 유지해서 표시함
        m_ReticleTransform.position = position + forward * m_DefaultDistance;

        // 리티클의 스케일을 카메라 시선 방향을 기준으로 설정함
        m_ReticleTransform.localScale = m_OriginalScale * m_DefaultDistance;

        // 리티클의 회전을 기본 회전값으로 적용함
        m_ReticleTransform.localRotation = m_OriginalRotation;
    }
}