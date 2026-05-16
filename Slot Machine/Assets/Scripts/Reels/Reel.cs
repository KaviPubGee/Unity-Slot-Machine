using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Reel : MonoBehaviour
{
    [SerializeField] private Image symbolImage;
    [SerializeField] private float symbolChangeDelay = 0.08f;

    private SlotSymbol currentSymbol;

    //A method that allows the slot machine manager to check which symbol this reel stopped on.
    public SlotSymbol CurrentSymbol
    {
        get { return currentSymbol; }
    }

     // Spins the reel by rapidly changing the symbol image for a set amount of time.
    public IEnumerator Spin(SlotSymbol[] symbols, float spinTime)
    {
        float timer = 0f;

        while (timer < spinTime)
        {
            //Get random number
            int randomIndex = Random.Range(0, symbols.Length);

            //change the symbol according to the random number we get
            currentSymbol = symbols[randomIndex];
            symbolImage.sprite = currentSymbol.symbolSprite;

            timer += symbolChangeDelay;

            yield return new WaitForSeconds(symbolChangeDelay);
        }

        // Choose the final symbol shown when the reel stops.
        int finalIndex = Random.Range(0, symbols.Length);

        currentSymbol = symbols[finalIndex];
        symbolImage.sprite = currentSymbol.symbolSprite;
    }
}