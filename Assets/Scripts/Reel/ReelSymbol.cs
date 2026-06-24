using UnityEngine;
using UnityEngine.UI;

public class ReelSymbol : MonoBehaviour
{
    public Image image;
    public GameObject glow;
    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }
}