using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomColor : MonoBehaviour
{
    //������ ������ ����
    [SerializeField] private float hueMin = 0f;
    [SerializeField] private float hueMax = 1f;
    [SerializeField] private float saturationMin = 0.7f;
    [SerializeField] private float saturationMax = 1f;
    [SerializeField] private float valueMin = 0.7f;
    [SerializeField] private float valueMax = 1f;

    public UnityEvent<Color> OnCreated;

    public void Call()
    {
        //�������� ���� ���ϰ�
        var color = Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax);

        OnCreated?.Invoke(color);
    }
}
