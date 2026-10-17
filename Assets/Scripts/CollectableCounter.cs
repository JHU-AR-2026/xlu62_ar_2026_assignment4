
using UnityEngine;
using TMPro;

public class CollectableCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public int totalCollectables = 10;
    public GameObject powerUpCapsule;
    private int collectedCount = 0;

    void Start()
    {
        UpdateCounter();
    }

    public void Collect()
    {
        collectedCount++;
        UpdateCounter();

        if (collectedCount >= totalCollectables)
        {
            powerUpCapsule.SetActive(true);
        }
    }

    void UpdateCounter()
    {
        if (counterText != null)
        {
            counterText.text = collectedCount + " / " + totalCollectables;
        }
    }
}
