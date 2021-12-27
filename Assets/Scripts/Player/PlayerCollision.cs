using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    // List of the player's navigation's arrows buttons
    [SerializeField] private List<Button> arrows = new List<Button>();
    // Layer mask to include only border's game objects in the collider detection
    [SerializeField] private LayerMask bordersLayerMask;

    private PlayerManager playerManagerScript;

    // Start is called before the first frame update

    void Start()
    {
        playerManagerScript = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Drawing gizmos lines across all 4 directions to identify if collide with something
        //DrawCollisionLines();
        
        // Checking whether player is hitting colliders and turning off/on
        // the navigation buttons accordingly
        CheckButtons();
    }

    private void DrawCollisionLines()
    {
        Debug.DrawRay(transform.position, Vector2.left * 1.5f, Color.red);
        Debug.DrawRay(transform.position, Vector2.up * 1.5f, Color.red);
        Debug.DrawRay(transform.position, Vector2.right * 1.5f, Color.red);
        Debug.DrawRay(transform.position, Vector2.down * 1.5f, Color.red);
    }

    RaycastHit2D CheckDirection(int i)
    {
        RaycastHit2D hit2D = new RaycastHit2D();
        switch (i)
        {
            case 0:
                RaycastHit2D hitUp = Physics2D.Raycast(gameObject.transform.position, Vector2.up, 1.5f, bordersLayerMask);
                return hitUp;
            case 1:
                RaycastHit2D hitRight = Physics2D.Raycast(gameObject.transform.position, Vector2.right, 1.5f, bordersLayerMask);
                return hitRight;
            case 2:
                RaycastHit2D hitLeft = Physics2D.Raycast(gameObject.transform.position, Vector2.left , 1.5f, bordersLayerMask);
                return hitLeft;
            case 3:
                RaycastHit2D hitDown = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 1.5f, bordersLayerMask);
                return hitDown;
        }
        return hit2D;
    }
    
    private void CheckButtons()
    {
        List<int> aCounters = playerManagerScript.playerControllerScript.arrowsCounters;
        for (int i = 0; i < aCounters.Count; i++)
        {
            if (aCounters[i] > 0)
            {
                RaycastHit2D hit2D = CheckDirection(i);
                if (hit2D.collider != null)
                {
                    arrows[i].interactable = false;
                }
                else
                {
                    arrows[i].interactable = true;
                }
            }
            else
            {
                arrows[i].interactable = false;
            }
        }
    } 
}
