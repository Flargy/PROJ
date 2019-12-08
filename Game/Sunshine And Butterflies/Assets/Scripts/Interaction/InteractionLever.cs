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
    [SerializeField] private GameObject leverAxis = null;
    [SerializeField] private float QTETimer = 3.0f;
    [SerializeField] private float cutoffTime = 0.15f;
    [SerializeField] private List<Interactable> connectedSwitches = null;
    [SerializeField] private AudioSource correct;
    [SerializeField] private AudioSource incorrect;

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
    private Coroutine leverRotation = null;
    float t = 0;
    float leverPullDownTime = 0.0f;

    private AudioSource audioSource;
    public AudioClip pushDownLever;
    public AudioClip releaseLever;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            foreach (Interactable otherSwitch in connectedSwitches)
            {
                if (otherSwitch.interacting == false)
                {
                    otherSwitch.StartInteraction();
                }
            }
            rendererHolder.SetActive(true);
            rendererHolder.transform.LookAt(sceneCamera.transform.position, Vector3.up);
            interactingPlayer = player.GetComponent<PlayerQTE>();
            interactingPlayer.GetComponent<NewPlayerScript>().SwapLiftingState();
            interactingPlayer.SwapToQTE(this);
            activateQTE = StartCoroutine(StartQTE());
            leverRotation = StartCoroutine(RotateLever());
            interacting = true;
        }
    }

    public void ReceiveAnswer(int answerID)
    {
        if(takeInput == true)
        {
            takeInput = false;
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
            correct.Play();
        }
        else
        {
            abortQTE = true;
            StopCoroutine(activateQTE);
            StopCoroutine(leverRotation);
            StopQTE();
            incorrect.Play();
        }
    }

    private void StopQTE()
    {
        if (abortQTE == true && interactingPlayer != null)
        {
            takeInput = true;
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
            leverRotation = StartCoroutine(RotateLever());
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
        int newNumber = correctAnswer;
        while(abortQTE == false)
        {
            playerHasAnswered = false;
            while (newNumber == correctAnswer)
            {
                newNumber = Random.Range(0, 4);
            }
            correctAnswer = newNumber;
            //correctAnswer = Random.Range(correctAnswer + 1, 4) % 4;
            DisplayWantedInput();
            takeInput = true;
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

    private IEnumerator RotateLever()
    {
        leverPullDownTime = 0.0f;
        Vector3 currentRotation = leverAxis.transform.localRotation.eulerAngles;
        Vector3 endRotation = Vector3.zero;
        if (currentRotation.x == 0)
        {
            endRotation = new Vector3(60, 0, 0);
            // ^ljud
            Debug.Log("LjudPushDown");
            audioSource.PlayOneShot(pushDownLever);

        }
        else 
        {
            // andra ljudet
            Debug.Log("LjudRelease");
            audioSource.PlayOneShot(releaseLever);
        }

        while (leverPullDownTime < 1.0f)
        {
            leverPullDownTime += Time.deltaTime / 2;
            leverAxis.transform.localRotation = Quaternion.Euler(Vector3.Lerp(currentRotation, endRotation, leverPullDownTime));
            yield return new WaitForEndOfFrame();
        }
    }

    //public IEnumerator InteractionCooldown()
    //{
    //    interacting = true;
    //    yield return new WaitForSeconds(interactionCooldownTimer);
    //    interacting = false;
    //}

    
}
