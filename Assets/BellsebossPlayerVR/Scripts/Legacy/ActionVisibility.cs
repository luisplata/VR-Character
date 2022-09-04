using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.OpenXR.Input;

public class ActionVisibility : MonoBehaviour
{
    [SerializeField] private InputActionReference _actionReference = null;

    [SerializeField] private GameObject _target = null;

    private void OnEnable()
    {
        if (null == _target)
            _target = gameObject;

        _target.SetActive(false);

        if (_actionReference != null && _actionReference.action != null)
            StartCoroutine(UpdateVisibility());
    }

    private IEnumerator UpdateVisibility ()
    {
        while (isActiveAndEnabled)
        {
            if (_actionReference.action != null &&
                _actionReference.action.controls.Count > 0 &&
                _actionReference.action.controls[0].device != null &&
                OpenXRInput.TryGetInputSourceName(_actionReference.action, 0, out var actionName, OpenXRInput.InputSourceNameFlags.Component, _actionReference.action.controls[0].device))
            {
                _target.SetActive(true);
                break;
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
