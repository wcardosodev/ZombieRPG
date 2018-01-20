using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    GameObject player;

    [SerializeField] Image playerHealth;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        playerHealth.fillAmount = player.GetComponent<Health>().HealthAsPercentage;
    }
}
