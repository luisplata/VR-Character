using System;
using UnityEngine.InputSystem;

public class ButtonPressActionCustom : ActionControlCustom
{
    public Action<bool> IsPress;

    protected override void OnActionStarted(InputAction.CallbackContext ctx)
    {
        ServiceLocator.Instance.GetService<IDebugMediator>().LogR($"Button Pressed");
        IsPress?.Invoke(true);
    }

    protected override void OnActionCanceled(InputAction.CallbackContext ctx)
    {
        IsPress?.Invoke(false);
    }
}