using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private PlayerManager playerManagerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerManagerScript = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    private void Follow()
    {
        var position = gameObject.transform.position;
        mainCamera.transform.position = new Vector3(position.x, position.y, -10);
    }
}
