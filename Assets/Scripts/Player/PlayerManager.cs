using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    internal PlayerCollision playerCollisionScript;
    internal PlayerAnimation playerAnimationScript;
    internal PlayerController playerControllerScript;
    internal MapSystem mapSystemScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerCollisionScript = GetComponent<PlayerCollision>();
        playerAnimationScript = GetComponent<PlayerAnimation>();
        playerControllerScript = GetComponent<PlayerController>();
        mapSystemScript = GetComponent<MapSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
