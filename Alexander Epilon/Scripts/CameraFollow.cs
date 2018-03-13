using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject mainTarget;
    private GameObject currentTarget;

    [SerializeField]
    private float dampening = 1f;

    [SerializeField]
    private float secondsBeforeChangeBack = 4f;

    [SerializeField]
    private float shakeDampening = 0.9f;

    private float shakeIntensity;

    void Start()
    {
        currentTarget = mainTarget;
    }

    void Update()
    {
        float xTo = currentTarget.transform.position.x;
        float yTo = currentTarget.transform.position.y;

        float xx = (xTo - transform.position.x) / dampening;
        float yy = (yTo - transform.position.y) / dampening;

        Vector3 newCameraPosition = new Vector3(transform.position.x + xx, transform.position.y + yy, -10);

        transform.position = newCameraPosition;
        transform.position = new Vector3(transform.position.x + Random.Range(-shakeIntensity, shakeIntensity), transform.position.y + Random.Range(-shakeIntensity, shakeIntensity), -10);
        shakeIntensity *= shakeDampening;
    }

    public void ChangeTarget(GameObject newTarget)
    {
        currentTarget = newTarget;
        StartCoroutine(ChangeBack());
    }

    public void ScreenShake(float intensity)
    {
        shakeIntensity = intensity;
    }

    IEnumerator ChangeBack()
    {
        yield return new WaitForSeconds(secondsBeforeChangeBack);
        currentTarget = mainTarget;
    }
}