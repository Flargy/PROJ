using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionLever : Interactable
{
    [SerializeField] private List<AffectedObject> affected = null;
    [SerializeField] private GameObject rendererHolder = null;
    [SerializeField] private GameObject clockHand = null;
    [SerializeField] private List<Sprite> sprites = null;
    [SerializeField] private GameObject sceneCamera = null;
    [SerializeField] private float QTETimer = 3.0f;
    [SerializeField] private float cutoffTime = 0.15f;
    private PlayerQTE interactingPlayer = null;
    private int correctAnswer = 0;
    private int playerAnswer = 0;
    //private bool interacting = false;
    private bool abortQTE = false;
    private float originalQTETimer = 0.0f;
    private bool takeInput = true;
    private bool playerHasAnswered = false;
    private SpriteRenderer renderQTE = null;
    private Coroutine activateQTE = null;
    float t = 0;


    private void Start()
    {
        renderQTE = rendererHolder.GetComponent<SpriteRenderer>();
        rendererHolder.SetActive(false);
        originalQTETimer = QTETimer;
    }

    public override void Interact(GameObject player)
    {
        if (interacting == false)
        {
            foreach(AffectedObject affectedObject in affected)
            {
                affectedObject.ExecuteAction();
            }
            rendererHolder.SetActive(true);
            rendererHolder.transform.LookAt(sceneCamera.transform.position, Vector3.up);
            interactingPlayer = player.GetComponent<PlayerQTE>();
            interactingPlayer.GetComponent<NewPlayerScript>().SwapLiftingState();
            interactingPlayer.SwapToQTE(this);
            activateQTE = StartCoroutine(StartQTE());
            interacting = true;
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
            renderQTE.sprite = null;
        }
        else
        {
            abortQTE = true;
            StopCoroutine(activateQTE);
            StopQTE();
        }
    }

    private void StopQTE()
    {
        if (abortQTE == true && interactingPlayer != null)
        {
            rendererHolder.SetActive(false);
            interactingPlayer.GetComponent<NewPlayerScript>().SwapLiftingState();
            interactingPlayer.SwapToMovement();
            QTETimer = originalQTETimer;
            playerAnswer = 0;
            abortQTE = false;
            correctAnswer = 0;
            interactingPlayer = null;
            renderQTE.sprite = null;
            playerHasAnswered = false;
            StartCoroutine(InteractionCooldown());
            foreach (AffectedObject affectedObject in affected)
            {
                affectedObject.ExecuteAction();
            }

            if(clockHand != null)
            {
                clockHand.SetActive(false);
            }

        }
    }

    private void DisplayWantedInput()
    {
        renderQTE.sprite = sprites[correctAnswer];
        if(clockHand != null)
        {

            clockHand.SetActive(true);
            StartCoroutine(TurnClock());
        }
    }

    private IEnumerator StartQTE()
    {
        while(abortQTE == false)
        {
            playerHasAnswered = false;
            correctAnswer = Random.Range(correctAnswer + 1, 4) % 4;
            DisplayWantedInput();
            yield return new WaitForSeconds(QTETimer);
            QTETimer -= cutoffTime;
            if(playerHasAnswered == false)
            {
                abortQTE = true;
            }
            
        }
        StopQTE();
    }

    private IEnumerator TurnClock()
    {
        clockHand.transform.localRotation = Quaternion.Euler(Vector3.zero);
        while (t <  0.99f)
        {
            t += Time.deltaTime / QTETimer;
            clockHand.transform.localRotation = Quaternion.Euler(Vector3.Lerp(Vector3.zero, new Vector3(0, 0, 358), t));

            yield return new WaitForEndOfFrame();
        }

        t = 0;
    }

    //public IEnumerator InteractionCooldown()
    //{
    //    interacting = true;
    //    yield return new WaitForSeconds(interactionCooldownTimer);
    //    interacting = false;
    //}

    
}
