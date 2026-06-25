// Reel System Implemented
using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Reel : MonoBehaviour
{
    public ReelSymbol symbol;

    [HideInInspector]
    public SymbolData currentSymbol;

    [Header("Spin Settings")]
    public float baseSpinDuration = 1.5f;

    public IEnumerator Spin(
        SymbolData[] allSymbols,
        SymbolData finalSymbol,
        float extraTime)
    {
        float spinTime = baseSpinDuration + extraTime;
        float timer = 0f;

        while (timer < spinTime)
        {
            int randomIndex = Random.Range(0, allSymbols.Length);

            symbol.SetSprite(allSymbols[randomIndex].sprite);

            yield return new WaitForSeconds(0.05f);

            timer += 0.05f;
        }

        currentSymbol = finalSymbol;

        symbol.SetSprite(finalSymbol.sprite);

        symbol.transform.localScale = Vector3.one;

        symbol.transform
            .DOScale(1.2f, 0.15f)
            .SetLoops(2, LoopType.Yoyo);
    }

    public IEnumerator FlashWin()
    {
        for (int i = 0; i < 4; i++)
        {
            symbol.image.color = Color.yellow;

            yield return new WaitForSeconds(0.15f);

            symbol.image.color = Color.white;

            yield return new WaitForSeconds(0.15f);
        }
    }
}