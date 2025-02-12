using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class UnderwaterDepth : MonoBehaviour
{
    [Header("Depth Parameters")]
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float depth = 0;
    [SerializeField] private float endwater = 0;

    [Header("Post Processing Volume")]
    [SerializeField] private Volume postProcessingVolume;

    [Header("Post Processing Profiles")]
    [SerializeField] private VolumeProfile surfacePostProcessing;
    [SerializeField] private VolumeProfile underwaterPostProcessing;

    private void Update()
    {
        if (mainCamera.position.y < depth && mainCamera.position.y>endwater)
        {
            EnableEffects(true);
        }
        else
        {
            EnableEffects(false);
        }
    }

    private void EnableEffects(bool active)
    {
        if (active)
        {
            postProcessingVolume.profile = underwaterPostProcessing;
        }
        else
        {
            postProcessingVolume.profile = surfacePostProcessing;
        }
    }
}
