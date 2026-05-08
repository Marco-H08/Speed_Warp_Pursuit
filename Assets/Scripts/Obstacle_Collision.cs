using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private DistanceCounter distanceCounter;

    void Start()
    {
        distanceCounter = GetComponent<DistanceCounter>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            TriggerGameOver();
        }
    }

    // Neu: für KillZone (Trigger)
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        int finalScore = distanceCounter != null ? distanceCounter.GetCounter() : 0;
        GameManager.Instance.GameOver(finalScore);
    }
}