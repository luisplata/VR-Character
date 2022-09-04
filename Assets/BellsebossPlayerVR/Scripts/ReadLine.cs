using System;
using UnityEngine.InputSystem;

public class ReadLine : ActionControlCustom
{
    public Action<float> Line;
    
    protected override void OnActionPerformed(InputAction.CallbackContext ctx) => UpdateValue(ctx);
    protected override void OnActionStarted(InputAction.CallbackContext ctx) => UpdateValue(ctx);
    protected override void OnActionCanceled(InputAction.CallbackContext ctx) => UpdateValue(ctx);

    private void UpdateValue(InputAction.CallbackContext ctx) => Line?.Invoke(ctx.ReadValue<float>());
}