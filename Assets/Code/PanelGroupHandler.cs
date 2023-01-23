using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGroupHandler : MonoBehaviour
{
    [SerializeField] List<PanelGroup> panelGroups = new List<PanelGroup>();

    bool idcyoubrokeyourelbow = true;

    private void Start()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            PanelGroup curGroup = transform.GetChild(i).GetComponent<PanelGroup>();
            if (curGroup == null) continue;
            if (!panelGroups.Contains(curGroup))
                panelGroups.Add(curGroup);
        }

        SetGroupActive(panelGroups[0]);
    }

    public void SetGroupActive(PanelGroup panelGroup)
    {
        if (panelGroup.gameObject.activeInHierarchy && !idcyoubrokeyourelbow) return;
        idcyoubrokeyourelbow = false;
        List<PanelGroup> setActiveThisRound = new List<PanelGroup>();
        List<PanelGroup> setDisactiveThisRound = new List<PanelGroup>();
        foreach (PanelGroup p in panelGroups)
        {
            if (p.gameObject.activeInHierarchy && p != panelGroup)
                setDisactiveThisRound.Add(p);
            if (!p.gameObject.activeInHierarchy && p == panelGroup)
                setActiveThisRound.Add(p);
            p.gameObject.SetActive(p == panelGroup);
        }
        foreach(PanelGroup p in setDisactiveThisRound)
            p.onDeactivate?.Invoke();
        foreach (PanelGroup p in setActiveThisRound)
            p.onActivate?.Invoke();
    }

    public void SetGroupActiveSoft(PanelGroup panelGroup)
    {
        if (!panelGroup.gameObject.activeInHierarchy)
            panelGroup.onActivate?.Invoke();
        panelGroup.gameObject.SetActive(true);
    }

    public void SetDeactiveSoft(PanelGroup panelGroup)
    {
        if (panelGroup.gameObject.activeInHierarchy)
            panelGroup.onDeactivate?.Invoke();
        panelGroup.gameObject.SetActive(false);
    }
}
