using UnityEngine;
public class Followcamera_G : MonoBehaviour
{
    [Header("Kamera-Einstellungen")]
    public Vector3 offset = new Vector3(0f, 5f, -10f);
    public float smoothSpeed = 5f;
    public bool lookAtTarget = true;

    private Transform target;

    void Start()
    {
        FindBall();
    }

    void FindBall()
    {
        GameObject ball = GameObject.Find("Ball");
        if (ball != null)
            target = ball.transform;
        else
            Debug.LogError("Kugel 'Ball' nicht gefunden!");
    }

    void LateUpdate()
    {
        if (target == null)
        {
            FindBall();
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        if (lookAtTarget)
            transform.LookAt(target);
    }
}