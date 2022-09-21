using System.Collections;
using UnityEngine;

public class DebugMediator : MonoBehaviour, IDebugMediator
{
    [SerializeField] private DebugAdapter debugLeft, debugRight;

    private void Start()
    {
        ServiceLocator.Instance.RegisterService<IDebugMediator>(this);
        debugLeft.gameObject.SetActive(false);
        debugRight.gameObject.SetActive(false);
    }

    public void LogL(string message)
    {
        if (!debugLeft.gameObject.activeSelf)
        {
            debugLeft.gameObject.SetActive(true);
        }
        debugLeft.Log(message);
    }
    
    public void LogR(string message)
    {
        if (!debugRight.gameObject.activeSelf)
        {
            debugRight.gameObject.SetActive(true);
        }
        debugRight.Log(message);
    }

    IEnumerator DisableLog(GameObject go)
    {
        yield return new WaitForSeconds(10);
        
    }
}