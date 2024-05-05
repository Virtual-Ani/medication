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

    public UnityEvent OnReloadStart;//������ ����
    public UnityEvent OnReloadEnd;//������ ��

    //�Ѿ˰����� �ٲ�� �˷��ִ� �̺�Ʈ
    public UnityEvent<int> OnBulletChange;
    //��% �����ƴ��� �˷��ִ� �̺�Ʈ
    public UnityEvent<float> OnChargeChange;

    private void Start()
    {
        currentBullet = maxBullet;
    }

    //�Ѿ� ���
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

    //����
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

        var beginTime = Time.time;//����ð�
        var beginBullet = currentBullet;//�����Ѿ�
        var enoughPercent = 1f - ((float)currentBullet / maxBullet);//�ۼ�Ʈ
        var enoughChargingTime = chargingTime * enoughPercent;//���� �ð�

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
