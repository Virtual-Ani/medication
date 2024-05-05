using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReturnToTarget : MonoBehaviour
{
    [SerializeField] private Transform target;

    private float duration = 1f;
    [SerializeField] private AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1f, 1f);

    public UnityEvent OnCompleted;

    public void Call()
    {
        StopAllCoroutines();
        StartCoroutine(Process());
    }

    IEnumerator Process()
    {
        if (target == null) yield break;

        var beginTime = Time.time;

        while (true)
        {
            var t = (Time.time - beginTime) / duration;
            if (t >= 1f)
                break;

            t = curve.Evaluate(t);//커브 계산

            transform.position = Vector3.Lerp(transform.position, target.position, t);

            yield return null;
        }

        OnCompleted?.Invoke();
    }
}
