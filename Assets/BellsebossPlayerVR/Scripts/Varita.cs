using UnityEngine;

public class Varita : CatchObjectFather
{
    [SerializeField] private GameObject pointInSpace;
    public HandActionsCustom Hand => _hand;
    public GameObject PointInSpace => pointInSpace;
}