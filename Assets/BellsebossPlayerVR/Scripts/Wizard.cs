using UnityEngine;

public class Wizard : MonoBehaviour
{
    [SerializeField] private Varita varita;
    [SerializeField] private Spell hechizo;

    private float _deltaTimeMoving;

    // Update is called once per frame
    void Update()
    {
        if (!varita.CanToUse) return;
        if (varita.Hand.GetBody().GetOtherHand(varita.Hand).TriggerPress() || varita.Hand.TriggerPress())
        {
            if (varita.Hand.TriggerPress())
            {
                if (!hechizo.isMoveVaritaToSpell)
                {
                    hechizo.StartMovement();   
                }
                hechizo.AddDeltaTime(varita.PointInSpace.transform.position);
            }
            else
            {
                hechizo.FinishedMovement();
            }

            if (varita.Hand.GetBody().GetOtherHand(varita.Hand).TriggerPress())
            {

            }
        }
    }
}