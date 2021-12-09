using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    internal PlayerCollision playerCollisionScript;
    internal PlayerAnimation playerAnimationScript;
    internal PlayerController playerControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerCollisionScript = GetComponent<PlayerCollision>();
        playerAnimationScript = GetComponent<PlayerAnimation>();
        playerControllerScript = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
