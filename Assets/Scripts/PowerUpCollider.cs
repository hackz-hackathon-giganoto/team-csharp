using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollider : MonoBehaviour
{
    [SerializeField]
    private int amountPowerIncrease;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStatus>().IncreasePlayerPower(amountPowerIncrease);
            Destroy(this.gameObject);
        }
    }
}
