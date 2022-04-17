using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDStatistics : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Start()
    {
        AppData.Instance.OnCreateEvent += UpdateHUD;
        AppData.Instance.OnDestroyedEvent += UpdateHUD;
    }

    void UpdateHUD()
    {
        if (text != null)
        {
            text.text = "Created GameObjects: " + AppData.Instance.CreatedGameObjects;
            text.text += "\nDestroyed GameObjects: " + AppData.Instance.DestroyedGameObjects;
            text.text += "\nShowing GameObjects: " + AppData.Instance.ShowingGameObjects;
        }
    }
}
