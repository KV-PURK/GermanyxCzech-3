using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private static CameraShake _singleton;

    public static CameraShake Singleton
    {
        get => _singleton;

        set
        {
            if (_singleton == null)
            {
                _singleton = value;
            }
            else
            {
                Debug.LogWarning($"{nameof(CameraShake)} Instance already exists, destroying duplicate");
                Destroy(value);
            }
        }
    }

    [SerializeField] private CinemachineVirtualCamera cam;

    private float shakeTimer;

    private void Awake()
    {
        Singleton = this;
    }

    public void ShakeCamera(float time, float intensity)
    {
        CinemachineBasicMultiChannelPerlin cinemachine = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachine.m_AmplitudeGain = intensity;

        shakeTimer = time;
    }


    private void Update()
    {
        if (shakeTimer <= 0) return;

        shakeTimer -= Time.deltaTime;
        if (shakeTimer <= 0)
        {
            CinemachineBasicMultiChannelPerlin cinemachine = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cinemachine.m_AmplitudeGain = 0.0f;
        }
    }
}
