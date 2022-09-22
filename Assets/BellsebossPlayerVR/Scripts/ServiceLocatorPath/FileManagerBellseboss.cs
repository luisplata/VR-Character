using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class FileManagerBellseboss : IFileManager
{
    public async void SaveSpell(string nameOfSpell, List<Vector3> listOfPoints)
    {
        var points = listOfPoints.Aggregate("", (current, point) => current + $"{point}\n");
        var pathOfSpell = $"{Application.dataPath}/spells/{nameOfSpell}.txt";
        await File.WriteAllTextAsync(pathOfSpell, points);

        var result = await File.ReadAllTextAsync(pathOfSpell);
        Debug.Log(result);
    }
}