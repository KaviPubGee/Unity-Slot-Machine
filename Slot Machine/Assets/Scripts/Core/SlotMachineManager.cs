using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotMachineManager : MonoBehaviour
{
    [Header("Reels")]
    [SerializeField] private Reel[] reels;

    [Header("Symbols")]
    [SerializeField] private SlotSymbol[] symbols;

    [Header("UI")]
    [SerializeField] private Button leverButton;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text payoutText;
    [SerializeField] private GameObject leverIdleObject;
    [SerializeField] private GameObject leverPulledObject;

    [Header("Spin Settings")]
    [SerializeField] private float baseSpinTime = 1.2f;
    [SerializeField] private float extraDelayPerReel = 0.4f;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip leverPull;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip looseSound;

    private bool isSpinning = false;

    private void Start()
    {
        //When player clicks the lever run the StartSpin
        leverButton.onClick.AddListener(StartSpin);

        resultText.text = "Pull the lever!";
        payoutText.text = "Payout: -";
    }

    // Starts the slot machine spin when the lever button is clicked.    
    private void StartSpin()
    {
        if (isSpinning)
        {
            return;
        }

        //Check if there is a audio source
        if (!audioSource)
        {
            Debug.LogWarning("Please assign a audio source");
        }
        //Start the spinning process
        audioSource.PlayOneShot(leverPull);
        StartCoroutine(SpinRoutine());
    }

    private IEnumerator SpinRoutine()
    {
        isSpinning = true;
        leverButton.interactable = false;

        //Switch the lever to the pull state
        leverIdleObject.SetActive(false);
        leverPulledObject.SetActive(true);

        resultText.text = "Spinning...";
        payoutText.text = "Payout: -";

        //Tell all the reels to spin but at a different time
        for (int i = 0; i < reels.Length; i++)
        {
            float spinTime = baseSpinTime + (i * extraDelayPerReel);
            StartCoroutine(reels[i].Spin(symbols, spinTime));
        }

        float totalSpinTime = baseSpinTime + ((reels.Length - 1) * extraDelayPerReel);

        // Wait until the last reel has finished spinning before checking the result.
        yield return new WaitForSeconds(totalSpinTime + 0.2f);

        CheckResult();

        // Return the lever to its idle state after the spin ends.
        leverIdleObject.SetActive(true);
        leverPulledObject.SetActive(false);

        leverButton.interactable = true;
        isSpinning = false;
    }

    // Checks whether all reels stopped on the same symbol and updates the result UI.
    private void CheckResult()
    {
        SlotSymbol firstSymbol = reels[0].CurrentSymbol;

        bool allMatch = true;

        for (int i = 1; i < reels.Length; i++)
        {
            if (reels[i].CurrentSymbol.symbolName != firstSymbol.symbolName)
            {
                allMatch = false;
                break;
            }
        }

        if (allMatch)
        {
            //Check if there is a audio source
            if (!audioSource)
            {
                Debug.LogWarning("Please assign a audio source");
            }
            audioSource.PlayOneShot(winSound);

            resultText.text = "You Win!";
            payoutText.text = "Payout: +" + firstSymbol.payout;
        }
        else
        {
            //Check if there is a audio source
            if (!audioSource)
            {
                Debug.LogWarning("Please assign a audio source");
            }
            audioSource.PlayOneShot(looseSound);

            resultText.text = "Try Again!";
            payoutText.text = "Payout: 0";
        }
    }
}