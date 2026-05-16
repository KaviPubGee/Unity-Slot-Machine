using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Reel : MonoBehaviour
{
    [SerializeField] private Image symbolImage;
    [SerializeField] private float symbolChangeDelay = 0.08f;

    private SlotSymbol currentSymbol;

    public SlotSymbol CurrentSymbol
    {
        get { return currentSymbol; }
    }

    public IEnumerator Spin(SlotSymbol[] symbols, float spinTime)
    {
        float timer = 0f;

        while (timer < spinTime)
        {
            int randomIndex = Random.Range(0, symbols.Length);

            currentSymbol = symbols[randomIndex];
            symbolImage.sprite = currentSymbol.symbolSprite;

            timer += symbolChangeDelay;

            yield return new WaitForSeconds(symbolChangeDelay);
        }

        int finalIndex = Random.Range(0, symbols.Length);

        currentSymbol = symbols[finalIndex];
        symbolImage.sprite = currentSymbol.symbolSprite;
    }
}