using System;
using UnityEngine;

public class CatchObjects : MonoBehaviour
{
    [SerializeField] private HandActionsCustom hand;
    [SerializeField] private string tagToCatch;
    [SerializeField] private GameObject referentToParent;
    private GameObject objectCatch;
    private bool _cachingInHand;
    
    private void Update()
    {
        if (hand.CatchPress())
        {
            Catch();
        }
        else
        {
            Release();
        }
    }

    private void Release()
    {
        if (!_cachingInHand) return;
        if(objectCatch == null) return;
        objectCatch.AddComponent<Rigidbody>().useGravity = true;
        objectCatch.transform.SetParent(null);
        _cachingInHand = false;
        if (objectCatch.TryGetComponent<CatchObjectFather>(out var catchObjecttemp))
        {
            catchObjecttemp.Release();
        }
    }

    private void Catch()
    {
        if (objectCatch == null) return;
        if (_cachingInHand) return;
        if (objectCatch.TryGetComponent<CatchObjectFather>(out var catchObjecttemp))
        {
            catchObjecttemp.Configurate(hand);
            Destroy(objectCatch.GetComponent<Rigidbody>());
            objectCatch.transform.SetParent(referentToParent.transform);
            objectCatch.transform.localPosition = Vector3.zero;
            objectCatch.transform.localRotation = Quaternion.identity;
            //objectCatch.transform.localRotation = referentToParent.transform.localRotation;
            _cachingInHand = true;
            ServiceLocator.Instance.GetService<IDebugMediator>().LogL($"Catch object");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToCatch))
        {
            ServiceLocator.Instance.GetService<IDebugMediator>().LogL($"{other.gameObject.tag} == {tagToCatch}");
            objectCatch = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagToCatch))
        {
            ServiceLocator.Instance.GetService<IDebugMediator>().LogL($"{other.gameObject.tag} == {tagToCatch}");
            objectCatch = null;
        }
    }
}
