using UnityEngine;

// Stores the data for one slot symbol, including its display image and payout value.
[System.Serializable]
public class SlotSymbol
{
    public string symbolName;
    public Sprite symbolSprite;
    public int payout;
}