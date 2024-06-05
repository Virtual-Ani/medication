using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medicine : MonoBehaviour
{
    public exGameManager exGameManager;
    // Start is called before the first frame update
    void Start()
    {
        // Find the exGameManager object if it's not assigned in the inspector
        if (exGameManager == null)
        {
            exGameManager = FindObjectOfType<exGameManager>();
        }

        if (exGameManager != null)
        {
            Debug.Log("gotcha! exGameManager!");
        }
        else
        {
            Debug.LogError("exGameManager is not assigned!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("medicine"))
        {

            Debug.Log("�浹! �� ���Ҵ�");

            exGameManager.putMedicine = true;
        }
        else
        {
            Debug.Log("�浹!!!!!! ");
            exGameManager.putMedicine = true;
            if (exGameManager.putMedicine == true)
            {
                Debug.Log("�� ���Ҵ�!!!!!");
            }
        }
    }
}
