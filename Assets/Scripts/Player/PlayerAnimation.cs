using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerManager playerManagerScript;
    private string currentState;
    internal Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
            return;
        else
        {
            currentState = newState;
            anim.Play(currentState);
        }
    }
}
