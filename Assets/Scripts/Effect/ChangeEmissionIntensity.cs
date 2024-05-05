using System.Collections;
using System.Collections.Generic;
//using Unity.Mathematics;
using UnityEngine;

public class ChangeEmissionIntensity : MonoBehaviour
{
    [SerializeField] private float min = 0f;
    [SerializeField] private float max = 3f;

    private Renderer target;

    private void Awake()
    {
        target = GetComponent<Renderer>();
    }

    public void Call(float ratio)
    {
        var intensity = Mathf.Lerp(min, max, ratio);
        target.materials[2].SetColor("_EmissionColor", target.material.color * intensity);
    }
}
