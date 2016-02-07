using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class Combat : NetworkBehaviour
{
    public const int maxHealth = 100;
    [SyncVar]
    public int health = maxHealth;

    Slider healthBar;
    Text score;

    void Start()
    {
        healthBar = GetComponentInChildren<Slider>();
        score = GameObject.FindObjectOfType<Text>();
    }

    public void TakeDamage(int amount)
    {
        if(!isServer)
        {
            return;
        }

        health -= amount;
       

        if (health <=0)
        {
            health = 0;
            Debug.Log("I'm dead Jim.");
            RpcReSpawn();
        }
    }

    void Update()
    {
        healthBar.value = health;
        score.text = "score: " + health;
    }

    [ClientRpc]
    void RpcReSpawn()
    {
        if(isLocalPlayer)
        {
            transform.position = Vector3.zero;
            health = maxHealth;
        }
    }
}
