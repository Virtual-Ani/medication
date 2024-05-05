using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private GameObject hitEffect;//맞은 위치의 이펙트
    [SerializeField] private Transform shootPoint;//총구

    [SerializeField] private float shootDelay = 0.1f;
    [SerializeField] private float maxDistance = 100f;

    //발사 성공했을때 부딪힌 지점에 대한 정보
    public UnityEvent<Vector3> OnShootSuccess;
    //발사 실패
    public UnityEvent OnShootFail;

    private Magazine magazine;//탄창

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

            //부딪힌 대상에 Hittable 컴포넌트가 있으면 Hit 실행
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
