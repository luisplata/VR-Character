using UnityEngine;

namespace Lab
{
    public class BookForRecord : MonoBehaviour
    {
        [SerializeField] private GeneralLab lab;

        public void StartRecord()
        {
            lab.StartRecord();
        }

        public void StopRecord()
        {
            lab.StopRecord();
        }
    }
}