using System.Collections.Generic;
using UnityEngine;

public interface IFileManager
{
    void SaveSpell(string nameOfSpell, List<Vector3> listOfPoints);
}