using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    private Player player;
    private PlayerSpawn pSpwn;
    private Transform target;
    public MovingTile lift1;
    public int playerLife;
    private float respwnCD = 2f;
    public bool playerDead = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        pSpwn = FindObjectOfType<PlayerSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDead)
        {
            playerLife--;
            player.gameObject.SetActive(false);
            respwnCD -= Time.deltaTime;
            if (respwnCD <= 0)
            {
                player.gameObject.transform.position = pSpwn.transform.position;
                player.gameObject.SetActive(true);
                player.Unlock();
                respwnCD = 2f;
                playerDead = false;
            }
            
        }
    }

    public void ChangeDestinationLift1()
    {
        lift1.isActive = true;
    }

    public void PlayerReturn()
    {
        pSpwn.Create();
    }
}
