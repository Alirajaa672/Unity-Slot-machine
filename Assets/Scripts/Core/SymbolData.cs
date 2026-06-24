using UnityEngine;

[CreateAssetMenu(fileName = "New Symbol",
menuName = "Slot Machine/Symbol")]
public class SymbolData : ScriptableObject
{
    public string symbolName;
    public Sprite sprite;
    public int payout;
}