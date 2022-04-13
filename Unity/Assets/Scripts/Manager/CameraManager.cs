using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : Singleton<CameraManager>
{
    public float ShakeTime;

    CinemachineVirtualCamera virtualCamera;
    CinemachineBasicMultiChannelPerlin shakeComponent;
    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        shakeComponent = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void CameraShake(float amplitude, float frequency, float time)
    {
        shakeComponent.m_AmplitudeGain = amplitude;
        shakeComponent.m_FrequencyGain = frequency;

        ShakeTime = time;
    }

    void Update()
    {
        if (ShakeTime > 0.0f)
        {
            ShakeTime -= Time.deltaTime;
        }
        else if (ShakeTime <= 0.0f)
        {
            shakeComponent.m_AmplitudeGain = 0;
            shakeComponent.m_FrequencyGain = 0;

            ShakeTime = 0;
        }    
    }

    public void DeathCameraShake()
    {
        shakeComponent.m_AmplitudeGain = 8;
        shakeComponent.m_FrequencyGain = 8;

        ShakeTime = 1f;
    }
}
