using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionLever : Interactable
{
    [SerializeField] private AffectedObject affected = null;

    private PlayerQTE interactingPlayer = null;
    private int correctAnswer = 0;
    private int playerAnswer = 0;
    private bool interacting = false;
    private bool abortQTE = false;
    private float QTETimer = 3.0f;
    private bool takeInput = true;
    private bool playerHasAnswered = false;

    public override void Interact(GameObject player)
    {
        if (interacting == false)
        {
            affected.ExecuteAction();
            interactingPlayer = player.GetComponent<PlayerQTE>();
            interactingPlayer.GetComponent<NewPlayerScript>().SwapLiftingState();
            interactingPlayer.SwapToQTE(this);
            StartCoroutine(StartQTE());
        }
    }

    public void ReceiveAnswer(int answerID)
    {
        if(takeInput == true)
        {
            playerHasAnswered = true;
            playerAnswer = answerID;
            CheckAnswer();

        }
    }

    private void CheckAnswer()
    {
        if(playerAnswer == correctAnswer)
        {
            abortQTE = false;
        }
        else
        {
            abortQTE = true;
            StopQTE();
        }
    }

    private void StopQTE()
    {
        if (abortQTE == true && interactingPlayer != null)
        {
            interactingPlayer.GetComponent<NewPlayerScript>().SwapLiftingState();
            interactingPlayer.SwapToMovement();
            QTETimer = 4.0f;
            playerAnswer = 0;
            abortQTE = false;
            correctAnswer = 0;
            interactingPlayer = null;
            playerHasAnswered = false;
            StartCoroutine(InteractionCooldown());
            
        }
    }

    private void DisplayWantedInput()
    {
        Debug.Log(correctAnswer);
    }

    private IEnumerator StartQTE()
    {
        while(abortQTE == false)
        {
            playerHasAnswered = false;
            correctAnswer = Random.Range(correctAnswer + 1, 4) % 4;
            DisplayWantedInput();
            yield return new WaitForSeconds(QTETimer);
            QTETimer -= 0.15f;
            if(playerHasAnswered == false)
            {
                abortQTE = true;
            }
            
        }
        StopQTE();
    }

    private IEnumerator InteractionCooldown()
    {
        yield return new WaitForSeconds(4.0f);
        interacting = false;
    }
}
