using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private float timeToMovementVarita;
    [SerializeField] private string nameOfSpell;
    [SerializeField] private LineRenderer line;
    private float _deltaTimeLocal = 100;
    private bool _isMoveVarita;
    private bool _isFinishedMovement = true;
    private Transform _firstPoint;
    private LineRenderer Line => line;
    public bool IsMoveVaritaToSpell => _isMoveVarita;

    private void Start()
    {
        line.positionCount = 0;
    }

    public void StartMovement(Transform firstPoint)
    {
        _isMoveVarita = true;
        _isFinishedMovement = false;
        _deltaTimeLocal = 0;
        Line.positionCount = 0;
        _firstPoint = firstPoint;
    }

    public void FinishedMovement()
    {
        if (_isFinishedMovement) return;
        _isMoveVarita = false;
        _isFinishedMovement = true;
        var listOfPoints = new List<Vector3>();
        for (int i = 0; i < line.positionCount; i++)
        {
            listOfPoints.Add(_firstPoint.InverseTransformPoint(line.GetPosition(i)));
        }

        var result = $"{listOfPoints.Count} points";
        ServiceLocator.Instance.GetService<IFileManager>().SaveSpell(nameOfSpell, listOfPoints);
        ServiceLocator.Instance.GetService<IDebugMediator>().LogR(result);
    }

    public void AddDeltaTime(Vector3 positionVarita)
    {
        if(!_isMoveVarita) return;
        _deltaTimeLocal += Time.deltaTime;
        if (_deltaTimeLocal >= timeToMovementVarita)
        {
            return;
        }
        var positionCount = Line.positionCount;
        positionCount += 1;
        Line.positionCount = positionCount;
        var position = positionCount - 1;
        Line.SetPosition(position, positionVarita);
    }
}