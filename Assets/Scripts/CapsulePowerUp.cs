
using UnityEngine;
using TMPro;

public class CapsulePowerUp : MonoBehaviour
{
    public float speedMultiplier = 5f;
    public TextMeshProUGUI statusText;

    private bool activated = false;

    private void Start()
    {
        if (statusText != null)
            statusText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (activated || !other.CompareTag("Player"))
            return;

        PlayerControl player = other.GetComponent<PlayerControl>();

        if (player == null)
            return;

        activated = true;

        Renderer rend = other.GetComponentInChildren<Renderer>();

        if (rend != null)
        {
            Material mat = rend.material;

            Color palePink = new Color(1f, 0.4f, 0.7f, 1f);

            if (mat.HasProperty("_BaseColor"))
                mat.SetColor("_BaseColor", palePink);
            else if (mat.HasProperty("_Color"))
                mat.SetColor("_Color", palePink);
        }
        else
        {
            Debug.LogWarning("Could not find the player's Renderer!");
        }

        // Increase speed permanently
        player.ApplySpeedBoost(speedMultiplier);

        // Show the power-up message
        if (statusText != null)
        {
            statusText.gameObject.SetActive(true);
        }

        // Remove the capsule
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Rotate(Vector3.right, 100 * Time.deltaTime);
    }
}
