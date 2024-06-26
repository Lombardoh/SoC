using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class UIUtils 
{
    public static void CreatePanelInformation(Transform parent, Dictionary<ResourceType, int> resources, Color color, float verticalOffset, float fontSize, float separation)
    {
        int index = 0;
        foreach (var resource in resources) 
        {
            CreateTextPair(parent, resource.Key.ToString(), resource.Value.ToString(), color, fontSize, verticalOffset * index, separation);
            index++;
        }
    }
    public static GameObject CreateTextPair(Transform parent, string text1, string text2, Color color, float fontSize, float offset, float separation)
    {
        GameObject container = new(text1 + " Container " + offset);
        container.transform.SetParent(parent, false);
        
        RectTransform containerRect = container.AddComponent<RectTransform>();
        containerRect.anchorMin = new Vector2(0, 1);
        containerRect.anchorMax = new Vector2(0, 1);
        containerRect.pivot = new Vector2(0, 1);
        containerRect.anchoredPosition = new Vector2(0, -offset);
        containerRect.sizeDelta = new Vector2(0, 0);

        CreateResourceText(container.transform, text1, color, fontSize);
        CreateResourceText(container.transform, text2, color, fontSize, separation);

        return container;
    }
    public static GameObject CreateResourceText(Transform parent, string text, Color color, float fontSize, float offset = 0)
    {
        GameObject resourceNameText = new(text + " Resource", typeof(TextMeshProUGUI));
        TextMeshProUGUI resourceNameTextComponent = resourceNameText.GetComponent<TextMeshProUGUI>();
        RectTransform resourceNameTextRect = resourceNameText.GetComponent<RectTransform>();

        resourceNameText.transform.SetParent(parent, false);
        resourceNameTextComponent.text = text;
        resourceNameTextComponent.fontSize = fontSize;
        resourceNameTextComponent.color = color;

        resourceNameTextRect.anchorMin = new Vector2(0, 1);
        resourceNameTextRect.anchorMax = new Vector2(0, 1);
        resourceNameTextRect.pivot = new Vector2(0, 1);

        resourceNameTextRect.transform.localPosition += Vector3.right * offset; 

        return resourceNameText;
    }
}
