using UnityEngine;
using UnityEngine.UI;

public class ButtonWorkTypeHandler : MonoBehaviour
{
    public WorkType workType;
    public ActionType action;

    private void Start()
    {
        TryGetComponent<Button>(out Button button);
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    private void OnButtonClick()
    {
        WorkEvents.ChangeWorkingAmount?.Invoke(workType, action);
    }
}
