using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class lightEstimation : MonoBehaviour
{
    [SerializeField] private ARCameraManager _aRCameraManager;
    [SerializeField] private Light _light;

    private void OnEnable()
    {
        _aRCameraManager.frameReceived += FrameChanged;
    }

    private void OnDisable()
    {
        _aRCameraManager.frameReceived -= FrameChanged;
    }

    private void FrameChanged(ARCameraFrameEventArgs args)
    {
        if (args.lightEstimation.averageBrightness.HasValue)
        {
            Debug.Log(args.lightEstimation.averageBrightness.Value);
            _light.intensity = args.lightEstimation.averageBrightness.Value;
        }
        if (args.lightEstimation.averageColorTemperature.HasValue)
        {
            Debug.Log(args.lightEstimation.averageColorTemperature.Value);
            _light.colorTemperature = args.lightEstimation.averageColorTemperature.Value;
        }
        if (args.lightEstimation.colorCorrection.HasValue)
        {
            Debug.Log(args.lightEstimation.colorCorrection.Value);
            _light.color = args.lightEstimation.colorCorrection.Value;
        }
    }
}
