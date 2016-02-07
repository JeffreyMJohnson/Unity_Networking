using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        var hit = other.gameObject;
        var hitPlayer = hit.GetComponent<PlayerMove>();
        if(hitPlayer != null)
        {
            var combat = hit.GetComponent<Combat>();
            combat.TakeDamage(10);

            Destroy(gameObject);
        }
    }
	
}
