using UnityEngine;
using TMPro;

public class DistanceCounter : MonoBehaviour
{
    [Header("Referenzen")]
    public TMP_Text counterText;

    private Vector3 startPosition;
    private int counter = 0;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (Time.timeScale == 0f) return;

        float distanceZ = transform.position.z - startPosition.z;
        int newCounter = Mathf.FloorToInt(distanceZ / 25f);

        if (newCounter > counter)
            counter = newCounter;

        // Null-Check hinzugefügt
        if (counterText != null && counterText.gameObject.activeInHierarchy)
            counterText.text = "Distance: " + counter;
    }

    public int GetCounter()
    {
        return counter;
    }
}