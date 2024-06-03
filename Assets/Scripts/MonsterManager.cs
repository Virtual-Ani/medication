using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MonsterManager : MonoBehaviour
{
    private static MonsterManager instance;

    public static MonsterManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<MonsterManager>();

            return instance;
        }
    }
    public UnityEvent<Enemy> OnDestroy;

    private List<Enemy> mons = new List<Enemy>();
    public void OnDestroyed(Enemy mon)
    {
        if (mons.Remove(mon))
        {
            OnDestroy?.Invoke(mon);
        }
    }
}
