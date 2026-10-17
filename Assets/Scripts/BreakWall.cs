
using UnityEngine;

public class BreakWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        PlayerControl player =
            collision.gameObject.GetComponent<PlayerControl>();

        if (player == null || !player.IsPoweredUp)
            return;

        Destroy(gameObject);
        
    }
}
