﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{


    private Transform _currentSelection;
    public ISelector _selector;
    private ISelectionResponse _selectionResponse;
    private IRayProvider _rayProvider;
    private void Awake()
    {
        SceneManager.LoadScene("Environment", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        _selectionResponse = GetComponent<ISelectionResponse>();
        _rayProvider = GetComponent<IRayProvider>();
        _selector = GetComponent<ISelector>();
    }

    private void Update()
    {
        //determine Deselection response
        if (_currentSelection != null)
        {
            _selectionResponse.OnDeselect(_currentSelection);
        }
        _selector.Check(_rayProvider.CreateRay());
        _currentSelection = _selector.GetSelection();
        //determine selection response
        if (_currentSelection != null)
        {
            _selectionResponse.OnSelect(_currentSelection);
        }
    }
    
   
}