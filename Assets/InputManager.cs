using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static InputManager istance;

    public bool MenuOpenCloseInput;
    private PlayerInput _playerInput;
    private InputAction _Selezionato;
    private AnimatorController mamt;
    // Update is called once per frame
    public void Awake(){
        if (istance == null){
            istance = this;
        }

        _playerInput = GetComponent<PlayerInput>();
        _Selezionato = _playerInput.actions["MenuOpenClose"];
        mamt = GetComponent<AnimatorController>();
    }
}
