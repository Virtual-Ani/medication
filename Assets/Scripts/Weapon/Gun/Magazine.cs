using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Magazine : MonoBehaviour, IReloadable
{
    [SerializeField] private int maxBullet = 20;
    private float chargingTime = 2f;

    private int currentBullet;

    private int CurrentBullet
    {
        get => currentBullet;
        set
        {
            if (value < 0)
                currentBullet = 0;
            else if (value > maxBullet)
                currentBullet = maxBullet;
            else
                currentBullet = value;

            OnBulletChange?.Invoke(currentBullet);
            OnChargeChange?.Invoke((float)currentBullet / maxBullet);
        }
    }

    public UnityEvent OnReloadStart;//재장전 시작
    public UnityEvent OnReloadEnd;//재장전 끝

    //총알갯수가 바뀌면 알려주는 이벤트
    public UnityEvent<int> OnBulletChange;
    //몇% 충전됐는지 알려주는 이벤트
    public UnityEvent<float> OnChargeChange;

    private void Start()
    {
        currentBullet = maxBullet;
    }

    //총알 사용
    public bool Use(int amount = 1)
    {
        if(CurrentBullet >= amount)
        {
            CurrentBullet -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    //충전
    [ContextMenu("Reload")]
    public void StartReload()
    {
        if (currentBullet == maxBullet)
            return;

        StopAllCoroutines();
        StartCoroutine(Process());
    }

    public void EndReload()
    {
        StopAllCoroutines();
    }

    IEnumerator Process()
    {
        OnReloadStart?.Invoke();

        var beginTime = Time.time;//현재시간
        var beginBullet = currentBullet;//현재총알
        var enoughPercent = 1f - ((float)currentBullet / maxBullet);//퍼센트
        var enoughChargingTime = chargingTime * enoughPercent;//남은 시간

        while (true)
        {
            var t = (Time.time - beginTime) / enoughChargingTime;
            if (t >= 1f)
                break;

            CurrentBullet = (int)Mathf.Lerp(beginBullet, maxBullet, t);
            yield return null;
        }

        OnReloadEnd?.Invoke();
    }

}
