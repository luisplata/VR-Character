using System;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    [SerializeField] private Varita varita;
    [SerializeField] private Spell hechizo;
    [SerializeField] private Transform zeroAbsolute;

    private float _deltaTimeMoving;

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!varita.CanToUse) return;
        if (!varita.Hand.GetBody().GetOtherHand(varita.Hand).TriggerTouch() && !varita.Hand.TriggerTouch()) return;
        if (varita.Hand.TriggerPress())
        {
            if (!hechizo.IsMoveVaritaToSpell)
            {
                zeroAbsolute.position = varita.PointInSpace.transform.position;
                zeroAbsolute.rotation = varita.PointInSpace.transform.rotation;
                hechizo.StartMovement(zeroAbsolute);   
            }
            hechizo.AddDeltaTime(varita.PointInSpace.transform.position);
        }
        else
        {
            hechizo.FinishedMovement();
        }

        try
        {
            return;
            if (varita.Hand.GetBody().GetOtherHand(varita.Hand).TriggerPress())
            {
                //ServiceLocator.Instance.GetService<IDebugMediator>().LogR($"Caster");
                ServiceLocator.Instance.GetService<ISpeechToText>().StartRecording();
            }
            else if(!varita.Hand.GetBody().GetOtherHand(varita.Hand).TriggerTouch())
            {
                ServiceLocator.Instance.GetService<ISpeechToText>().StopRecording(true);
                //ServiceLocator.Instance.GetService<IDebugMediator>().LogR($"Finish");
            }
        }
        catch (Exception e)
        {
            // ignored
        }
    }
}