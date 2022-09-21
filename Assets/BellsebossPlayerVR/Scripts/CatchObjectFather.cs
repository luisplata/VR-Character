using UnityEngine;

public abstract class CatchObjectFather : MonoBehaviour
{
    protected HandActionsCustom _hand;
    protected bool _canToUse;
    public bool CanToUse => _canToUse;
    public virtual void Configurate(HandActionsCustom hand)
    {
        _hand = hand;
        _canToUse = true;
    }

    public virtual void Release()
    {
        _hand = null;
        _canToUse = false;
    }
}