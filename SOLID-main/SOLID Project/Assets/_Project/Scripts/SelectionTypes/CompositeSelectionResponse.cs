using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CompositeSelectionResponse : MonoBehaviour, ISelectionResponse, IChangeable
{
    [SerializeField] private GameObject selectionResponseHolder;
    private List<ISelectionResponse> _selectionResponses;
    int count;
    private Transform currentSelection;
    private void Start()
    {
        _selectionResponses = selectionResponseHolder.GetComponents<ISelectionResponse>().ToList();
    }
    [ContextMenu(itemName:"Next")]
    public void Next()
    {
        if (currentSelection != null)
        {
            _selectionResponses[count].OnDeselect(currentSelection);
            count = (count + 1) % _selectionResponses.Count;
            _selectionResponses[count].OnSelect(currentSelection);
        }
    }
    public void OnDeselect(Transform selection)
    {
        currentSelection = null;
        _selectionResponses[count].OnDeselect(selection);
    }

    public void OnSelect(Transform selection)
    {
        currentSelection = selection;
        if (HasSelection())
        {
            _selectionResponses[count].OnSelect(selection);
        }
    }
    private bool HasSelection()
    {
        return count > -1 && count < _selectionResponses.Count;
    }
}
