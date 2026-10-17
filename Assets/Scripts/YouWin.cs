
using UnityEngine;
using TMPro;

public class YouWin : MonoBehaviour
{
    public GameObject winText;

    private bool hasWon = false;

    void Start()
    {
        if (winText != null)
            winText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasWon || !other.CompareTag("Player"))
            return;

        hasWon = true;

        if (winText != null)
            winText.SetActive(true);

        Time.timeScale = 0f;
    }
}
