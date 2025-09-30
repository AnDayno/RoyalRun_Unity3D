using System.Collections;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;

    float cooldownTimer = 0f;

    const string hitTrigger = "Hit";

    void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (cooldownTimer < collisionCooldown) return;

            animator.SetTrigger(hitTrigger);
            cooldownTimer = 0f;  
    }
}
