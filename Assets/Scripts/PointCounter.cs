using UnityEngine;
using UnityEngine.UI;
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
        // Wie weit in Z-Richtung seit Start
        float distanceZ = startPosition.z + transform.position.z;

        // Alle 25 Einheiten = 1 Punkt
        int newCounter = Mathf.FloorToInt(distanceZ / 25f);

        // Nur erhöhen, nie verringern
        if (newCounter > counter)
        {
            counter = newCounter;
        }

        // Anzeige aktualisieren
        if (counterText != null)
            counterText.text = "Distanz: " + counter;
    }
    public int GetCounter()
    {
        return counter;
    }
}
