using UnityEngine;

public class SpeedBoostZone : MonoBehaviour
{
    [Header("Boost Einstellungen")]
    public float boostKraft = 1f;
    public Vector3 boostRichtung = Vector3.forward;

    [Header("Optionen")]
    public bool einmalBoost = false;
    private bool bereitsAktiviert = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball")) return;
        if (einmalBoost && bereitsAktiviert) return;

        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb == null) return;

        Vector3 richtung = transform.TransformDirection(boostRichtung.normalized);
        rb.AddForce(richtung * boostKraft, ForceMode.Impulse);

        bereitsAktiviert = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 1f, 1f, 0.3f);
        Gizmos.DrawCube(transform.position, transform.localScale);
        Gizmos.color = Color.yellow;
        Vector3 richtung = transform.TransformDirection(boostRichtung.normalized);
        Gizmos.DrawRay(transform.position, richtung * 3f);
    }
}