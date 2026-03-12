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
            int finalScore = distanceCounter != null ? distanceCounter.GetCounter() : 0;
            Game_Manager.Instance.GameOver(finalScore);
        }
    }
}