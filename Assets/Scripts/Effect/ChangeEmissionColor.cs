using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEmissionColor : MonoBehaviour
{
    //��Ⱝ��
    [SerializeField] private float emissionIntensity = 5f;

    private Renderer target;

    private void Awake()
    {
        target = GetComponent<Renderer>();
    }

    public void Call(Color color)
    {
        //��Ƽ���� ������ Emission Color ���� �ٲ���
        target.material.SetColor("_EmissionColor", color * emissionIntensity);
    }
}
