using UnityEngine;

public class FollowTrigger : MonoBehaviour
{
    public GameObject Enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            EnemyFollow enemy = Enemy.GetComponent<EnemyFollow>();
            enemy.followPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            EnemyFollow enemy = Enemy.GetComponent<EnemyFollow>();
            enemy.followPlayer = false;
        }
    }
}