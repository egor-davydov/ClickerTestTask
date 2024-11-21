using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Gameplay
{
  public class ClickInput : MonoBehaviour
  {
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private string _actionNameOrId;
    
    private InputAction _inputAction;

    public event Action<Vector2> Started;
    
    private void Awake()
    {
      _inputAction = _playerInput.actions[_actionNameOrId];
    }

    private void Update()
    {
      if (_inputAction.WasPressedThisFrame() && !IsPointerOverUIObject())
        ClickStarted();
    }

    private void ClickStarted() => 
      Started?.Invoke(Pointer.current.position.ReadValue());

    public bool IsPointerOverUIObject() => 
      _playerInput.uiInputModule.IsPointerOverGameObject(Pointer.current.deviceId);
  }
}