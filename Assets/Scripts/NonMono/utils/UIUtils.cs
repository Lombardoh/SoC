using TMPro;
using UnityEngine;

public static class UIUtils 
{
    public static GameObject CreateResourceText(Transform parent, string Text)
    {
        GameObject resourceNameText = new(Text + " Resource", typeof(TextMeshProUGUI));
        TextMeshProUGUI resourceNameTextComponent = resourceNameText.GetComponent<TextMeshProUGUI>();
        resourceNameText.transform.SetParent(parent);
        resourceNameTextComponent.text = Text;
        resourceNameTextComponent.fontSize = 2;
        RectTransform resourceNameTextRect = resourceNameText.GetComponent<RectTransform>();
        resourceNameTextRect.anchorMin = new Vector2(0, 1);
        resourceNameTextRect.anchorMax = new Vector2(1, 1);
        resourceNameTextRect.pivot = new Vector2(0.5f, 1);
        resourceNameTextRect.offsetMin = new Vector2(0, 0);
        resourceNameTextRect.offsetMax = new Vector2(0, 30);

        return resourceNameText;
    }
}
