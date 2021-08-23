using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLabels : MonoBehaviour
{
    private List<string> m_labels = new List<string>();

    public GUIStyle style;

    public void Add(string label)
    {
        m_labels.Add(label);
    }
    
    public void Add(List<string> labels)
    {
        foreach (string s in labels)
            m_labels.Add(s);
    }

    private void OnGUI()
    {
        for (int i = 0; i < m_labels.Count; i++)
            GUI.Label(new Rect(0, 15 * i, 400, 100), m_labels[i], style);
    }

    private void Update()
    {
        m_labels.Clear();
    }
}