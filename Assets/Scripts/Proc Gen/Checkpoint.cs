using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float increaseTimeAmount = 5f;

    GameManager gameManager;

    const string PLAYER_TAG = "Player";

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            gameManager.IncreaseTime(increaseTimeAmount);
        }
    }
}
