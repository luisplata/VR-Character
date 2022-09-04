using System;
using UnityEngine.InputSystem;
using UnityEngine;

public class ReadVector2 : ActionControlCustom
{
    public Action<Vector2> Vector;
    
    protected override void OnActionPerformed(InputAction.CallbackContext ctx) => UpdateHandle(ctx);

    protected override void OnActionStarted(InputAction.CallbackContext ctx) => UpdateHandle(ctx);

    protected override void OnActionCanceled(InputAction.CallbackContext ctx) => UpdateHandle(ctx);

    private void UpdateHandle(InputAction.CallbackContext ctx)
    {
        Vector?.Invoke(ctx.ReadValue<Vector2>());
    }
}