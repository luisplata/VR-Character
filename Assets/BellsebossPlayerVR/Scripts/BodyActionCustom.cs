using UnityEngine;

public class BodyActionCustom : MonoBehaviour, IBodyAction
{
    [SerializeField] private HandActionsCustom left, right;

    private void Awake()
    {
        left.Configurate(this);
        right.Configurate(this);
    }

    public HandActionsCustom GetLeftHand()
    {
        return left;
    }

    public HandActionsCustom GetRightHand()
    {
        return right;
    }

    public HandActionsCustom GetOtherHand(HandActionsCustom hand)
    {
        return hand.GetHand() == HandName.LEFT ? right : left;
    }
}