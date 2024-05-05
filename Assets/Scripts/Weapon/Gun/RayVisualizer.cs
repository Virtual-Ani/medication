using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayVisualizer : MonoBehaviour
{
    [Header("Ray")]
    [SerializeField] private LineRenderer ray;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float distance = 100f;

    [Header("Reticle")]
    [SerializeField] private GameObject reticlePoint;
    [SerializeField] private bool showReticle = true;

    private void Awake()
    {
        Off();
    }

    public void On()
    {
        StopAllCoroutines();
        StartCoroutine(Process());
    }

    public void Off()
    {
        StopAllCoroutines();

        ray.enabled = false;
        reticlePoint.SetActive(false);
    }

    IEnumerator Process()
    {
        while (true)
        {
            if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo, distance, mask))
            {
                //¾îµò°¡ ºÎµúÇûÀ»¶§
                ray.SetPosition(1, transform.InverseTransformPoint(hitinfo.point));
                ray.enabled = true;

                reticlePoint.transform.position = hitinfo.point;
                reticlePoint.SetActive(showReticle);
            }
            else
            {
                //¾È ºÎµúÇûÀ»¶§
                ray.enabled = false;
                reticlePoint.SetActive(false);
            }

            yield return null;
        }
    }
}
