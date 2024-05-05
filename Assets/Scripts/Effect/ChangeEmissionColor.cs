using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEmissionColor : MonoBehaviour
{
    //밝기강도
    [SerializeField] private float emissionIntensity = 5f;

    private Renderer target;

    private void Awake()
    {
        target = GetComponent<Renderer>();
    }

    public void Call(Color color)
    {
        //머티리얼 가져다 Emission Color 색도 바꿔줌
        target.material.SetColor("_EmissionColor", color * emissionIntensity);
    }
}
