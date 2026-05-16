using System.Collections;
using UnityEngine;

public class Reel : MonoBehaviour
{
    [Header("Reel Strip")]
    [SerializeField] private RectTransform symbolStrip;

    [Header("Spin Settings")]
    [SerializeField] private float symbolHeight = 110f;
    [SerializeField] private float spinSpeed = 900f;

    private SlotSymbol currentSymbol;
    private Vector2 startPosition;

    // Lets the SlotMachineManager check which symbol this reel stopped on.
    public SlotSymbol CurrentSymbol
    {
        get { return currentSymbol; }
    }

    private void Awake()
    {
        // Save the original position of the symbol strip.
        // This is the position we use as the starting point for looping and stopping.
        startPosition = symbolStrip.anchoredPosition;
    }

    public IEnumerator Spin(SlotSymbol[] symbols, float spinTime)
    {
        float timer = 0f;

        // Pick the final symbol before the reel starts slowing down.
        // This decides what symbol the reel will stop on.
        int finalIndex = Random.Range(0, symbols.Length);
        currentSymbol = symbols[finalIndex];

        // The height of one full set of symbols.
        // Example: 4 symbols * 110 height = 440.
        // When the strip moves this far, we loop it back to the start.
        float loopHeight = symbolHeight * symbols.Length;

        // Keep moving the symbol strip while the reel is spinning.
        while (timer < spinTime)
        {
            timer += Time.deltaTime;

            Vector2 position = symbolStrip.anchoredPosition;

            // Move the whole symbol strip down smoothly.
            position.y -= spinSpeed * Time.deltaTime;

            // If the strip has moved too far, loop it back upward.
            // This makes the reel look like it is spinning endlessly.
            if (position.y <= startPosition.y - loopHeight)
            {
                position.y += loopHeight;
            }

            symbolStrip.anchoredPosition = position;

            // Wait until the next frame before continuing.
            yield return null;
        }

        // Calculate the exact position needed to stop on the chosen final symbol.
        Vector2 targetPosition = startPosition;
        targetPosition.y = startPosition.y - (finalIndex * symbolHeight);

        float settleTime = 0.25f;
        float settleTimer = 0f;

        Vector2 currentPosition = symbolStrip.anchoredPosition;

        // Smoothly move from the current spinning position to the final symbol position.
        while (settleTimer < settleTime)
        {
            settleTimer += Time.deltaTime;

            float t = settleTimer / settleTime;

            symbolStrip.anchoredPosition = Vector2.Lerp(currentPosition, targetPosition, t);

            yield return null;
        }

        // Force the final position to be exact so the symbol aligns cleanly.
        symbolStrip.anchoredPosition = targetPosition;
    }
}