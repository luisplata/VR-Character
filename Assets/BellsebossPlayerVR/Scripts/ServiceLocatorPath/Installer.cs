using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private SpeechToTextService speechToTextService;
    [SerializeField] private DebugMediator debugMediator;
    private void Awake()
    {
        if (FindObjectsOfType<Installer>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        ServiceLocator.Instance.RegisterService<ISpeechToText>(speechToTextService);
        ServiceLocator.Instance.RegisterService<IDebugMediator>(debugMediator);
        FileManagerBellseboss fileManaget = new FileManagerBellseboss();
        ServiceLocator.Instance.RegisterService<IFileManager>(fileManaget);
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 30;
    }
}