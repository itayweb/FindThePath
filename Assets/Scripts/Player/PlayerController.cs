using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // List of text game objects of the counters of navigation's buttons
    [SerializeField] private List<GameObject> arrowsCountersTexts = new List<GameObject>();
    // List of counters for each 4 buttons
    [SerializeField] internal List<int> arrowsCounters = new List<int>();
    // List of names for each 4 directions
    [SerializeField] private List<string> arrowsDirections = new List<string>();
    // The amount of x or y values to add to the walk direction
    [SerializeField] private float walkOffset;
    
    private PlayerManager playerManagerScript;
    private bool isFacingLeft = true;
    // If player started moving
    private bool isMoving;
    // The current position of player and the target position
    private Vector2 currentPos, targetPos;
    // The amount of time the player takes to move to target position
    private float timeToMove = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        playerManagerScript = GetComponent<PlayerManager>();
        // Initializing the text in each text counter
        InitializeTextCounters();
    }

    private void InitializeTextCounters()
    {
        for (int i = 0; i < arrowsCountersTexts.Count; i++)
        {
            arrowsCountersTexts[i].GetComponent<TextMeshProUGUI>().text = arrowsCounters[i].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveUp()
    {
        if (!isMoving)
        {
            playerManagerScript.playerAnimationScript.anim.Play("PlayerWalkUp");
            StartCoroutine(MovePlayer(Vector2.up + new Vector2(0, walkOffset)));
            for (int i = 0; i < arrowsDirections.Count; i++)
            {
                if (arrowsDirections[i] == "Up")
                {
                    arrowsCounters[i]--;
                    arrowsCountersTexts[i].GetComponent<TextMeshProUGUI>().text = arrowsCounters[i].ToString();
                }
            }
        }
    }

    public void MoveDown()
    {
        if (!isMoving)
        {
            playerManagerScript.playerAnimationScript.anim.Play("PlayerWalkDown");
            StartCoroutine(MovePlayer(Vector2.down + new Vector2(0, -walkOffset)));
            for (int i = 0; i < arrowsDirections.Count; i++)
            {
                if (arrowsDirections[i] == "Down")
                {
                    arrowsCounters[i]--;
                    arrowsCountersTexts[i].GetComponent<TextMeshProUGUI>().text = arrowsCounters[i].ToString();
                }
            }
        }
    }

    public void MoveLeft()
    {
        if (!isFacingLeft) { Flip(); }
        if (!isMoving)
        {
            playerManagerScript.playerAnimationScript.anim.Play("PlayerWalkSide");
            StartCoroutine(MovePlayer(Vector2.left+ new Vector2(-walkOffset, 0)));
            for (int i = 0; i < arrowsDirections.Count; i++)
            {
                if (arrowsDirections[i] == "Left")
                {
                    arrowsCounters[i]--;
                    arrowsCountersTexts[i].GetComponent<TextMeshProUGUI>().text = arrowsCounters[i].ToString();
                }
            }
        }
    }

    public void MoveRight()
    {
        if (isFacingLeft) { Flip(); }
        if (!isMoving)
        {
            playerManagerScript.playerAnimationScript.anim.Play("PlayerWalkSide");
            StartCoroutine(MovePlayer(Vector2.right+ new Vector2(walkOffset, 0)));
            for (int i = 0; i < arrowsDirections.Count; i++)
            {
                if (arrowsDirections[i] == "Right")
                {
                    arrowsCounters[i]--;
                    arrowsCountersTexts[i].GetComponent<TextMeshProUGUI>().text = arrowsCounters[i].ToString();
                }
            }
        }
    }
    
    // Takes a direction and move player object to that direction with lerp to smooth the transition
    IEnumerator MovePlayer(Vector2 direction)
    {
        isMoving = true;
        float elapsedTime = 0;
        currentPos = transform.position;
        targetPos = currentPos + direction;
        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(currentPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }

    void Flip()
    {
        isFacingLeft = !isFacingLeft;
        transform.Rotate(Vector3.up * 180);
    }
}
