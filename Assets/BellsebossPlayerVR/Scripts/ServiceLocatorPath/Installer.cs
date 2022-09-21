using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private SpeechToTextService speechToTextService;
    private void Awake()
    {
        if (FindObjectsOfType<Installer>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        ServiceLocator.Instance.RegisterService<ISpeechToText>(speechToTextService);
        DontDestroyOnLoad(gameObject);
    }
}