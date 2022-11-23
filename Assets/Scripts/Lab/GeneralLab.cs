using UnityEngine;

namespace Lab
{
    public class GeneralLab : MonoBehaviour
    {
        [SerializeField] private GameObject bookClosed, bookOpened;
        private bool isRecording;

        public void StartRecord()
        {
            isRecording = true;
            UpdateBook();
        }

        private void UpdateBook()
        {
            bookClosed.SetActive(!isRecording);
            bookOpened.SetActive(isRecording);
        }

        public void StopRecord()
        {
            isRecording = false;
            UpdateBook();
        }
    }
}