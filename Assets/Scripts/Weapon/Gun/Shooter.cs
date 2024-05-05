using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private GameObject hitEffect;//���� ��ġ�� ����Ʈ
    [SerializeField] private Transform shootPoint;//�ѱ�

    [SerializeField] private float shootDelay = 0.1f;
    [SerializeField] private float maxDistance = 100f;

    //�߻� ���������� �ε��� ������ ���� ����
    public UnityEvent<Vector3> OnShootSuccess;
    //�߻� ����
    public UnityEvent OnShootFail;

    private Magazine magazine;//źâ

    private void Awake()
    {
        magazine = GetComponent<Magazine>();
    }

    private void Start()
    {
        Stop();
    }

    public void Play()
    {
        StopAllCoroutines();
        StartCoroutine(Process());
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    IEnumerator Process()
    {
        var wfs = new WaitForSeconds(shootDelay);

        while (true)
        {
            if (magazine.Use())
            {
                Shoot();
            }
            else
            {
                OnShootFail?.Invoke();
            }

            yield return wfs;
        }
    }

    private void Shoot()
    {
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out RaycastHit hitinfo, maxDistance, mask))
        {
            Instantiate(hitEffect, hitinfo.point, Quaternion.identity);

            //�ε��� ��� Hittable ������Ʈ�� ������ Hit ����
            var hitObj = hitinfo.transform.GetComponent<Hittable>();
            hitObj?.Hit();

            OnShootSuccess?.Invoke(hitinfo.point);
        }
        else
        {
            var hitPoint = shootPoint.position + shootPoint.forward * maxDistance;
            OnShootSuccess?.Invoke(hitPoint);
        }
    }

}
