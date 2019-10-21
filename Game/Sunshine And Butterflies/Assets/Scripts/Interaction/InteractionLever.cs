using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionLever : Interactable
{
    private NewPlayerScript interactingPlayer = null;
    private int correctAnswer = 0;
    private bool interacting = false;
    private bool abortQTE = false;

    public override void Interact(GameObject player)
    {
        
    }

    public void ReceiveAnswer(int answerID)
    {

    }

    private IEnumerator StartQTE()
    {
        return null;
    }
}
