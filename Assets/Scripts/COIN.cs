using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 10; // Points added when collected

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(scoreValue);
            Debug.Log("Item Collected! +" + scoreValue + " points");
            Destroy(gameObject);
        }
    }
}
