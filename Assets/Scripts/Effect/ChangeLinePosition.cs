using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLinePosition : MonoBehaviour
{
    //몇번째 라인을 바꿀건지..
    [SerializeField] private int index;

    private LineRenderer target;

    private void Awake()
    {
        target = GetComponent<LineRenderer>();
    }

    public void Call(Vector3 worldPosition)
    {
        if (target.useWorldSpace)
        {
            //월드포지션
            target.SetPosition(index, worldPosition);
        }
        else
        {
            //로컬포지션
            var localPosition = transform.InverseTransformPoint(worldPosition);
            target.SetPosition(index, localPosition);
        }


    }

}
