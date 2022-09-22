using System;
using UnityEngine.InputSystem;

public class ButtonTouchActionCustom : ActionControlCustom
{
    public Action<bool> IsTouch;

    protected override void OnActionStarted(InputAction.CallbackContext ctx)
    {
        ServiceLocator.Instance.GetService<IDebugMediator>().LogR("Touch");
        IsTouch?.Invoke(true);
    }

    protected override void OnActionCanceled(InputAction.CallbackContext ctx)
    {
        IsTouch?.Invoke(false);
    }
}