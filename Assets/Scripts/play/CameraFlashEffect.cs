using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraFlashEffect : MonoBehaviour
{
    public float flashDuration = 0.2f;
    public float shakeIntensity = 0.5f;
    public Camera targetCamera;
    
    public GameObject uiPanel; // UI 패널 GameObject

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        if (targetCamera == null)
        {
            targetCamera = GetComponent<Camera>();
        }

        originalPosition = targetCamera.transform.position;
        originalRotation = targetCamera.transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayFlashEffect();
        }
    }

    public void PlayFlashEffect()
    {
        StartCoroutine(FlashCoroutine());
        uiPanel.SetActive(true); // UI 패널 활성화
    }

    private IEnumerator FlashCoroutine()
    {
        Color originalColor = targetCamera.backgroundColor;
        StartCoroutine(ShakeCamera(flashDuration, shakeIntensity));

        yield return new WaitForSeconds(flashDuration);

        targetCamera.backgroundColor = originalColor;
        uiPanel.SetActive(false); // UI 패널 비활성화
    }

    private IEnumerator ShakeCamera(float duration, float intensity)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            targetCamera.transform.position = originalPosition + Random.insideUnitSphere * intensity;
            targetCamera.transform.rotation = Quaternion.Euler(originalRotation.eulerAngles + new Vector3(
                Random.Range(-intensity, intensity),
                Random.Range(-intensity, intensity),
                Random.Range(-intensity, intensity)
            ));

            elapsed += Time.deltaTime;
            yield return null;
        }

        targetCamera.transform.position = originalPosition;
        targetCamera.transform.rotation = originalRotation;
    }
}
