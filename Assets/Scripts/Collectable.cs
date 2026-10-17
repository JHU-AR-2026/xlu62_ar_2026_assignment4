
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableCounter counter;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            counter.Collect();
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.right, 100 * Time.deltaTime);
    }
}
