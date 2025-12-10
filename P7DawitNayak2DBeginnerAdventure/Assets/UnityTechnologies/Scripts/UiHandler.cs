using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class UIHandler : MonoBehaviour
{
    private VisualElement m_Healthbar;
    public static UIHandler instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Get reference to HealthBar element
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        // DO NOT set width here — player health will control it
    }

    // Public function to set health (0 to 1)
    public void SetHealthValue(float percentage)
    {
        if (m_Healthbar != null)
        {
            m_Healthbar.style.width = Length.Percent(Mathf.Clamp01(percentage) * 100f);
        }
    }
}