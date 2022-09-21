using System;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private float timeToMovementVarita;
    [SerializeField] private LineRenderer line;
    private float _deltaTimeLocal = 100;
    private bool _isMoveVarita;
    public LineRenderer Line => line;
    public bool isMoveVaritaToSpell => _isMoveVarita;

    private void Start()
    {
        line.positionCount = 0;
    }

    public void StartMovement()
    {
        _isMoveVarita = true;
        _isFinishedMovement = false;
        _deltaTimeLocal = 0;
    }

    private bool _isFinishedMovement = true;
    public void FinishedMovement()
    {
        if (_isFinishedMovement) return;
        _isMoveVarita = false;
        _isFinishedMovement = true;
        var listOfPoints = new List<Vector3>();
        for (int i = 0; i < line.positionCount; i++)
        {
            listOfPoints.Add(line.GetPosition(i));
        }
        Debug.Log($"position \n{listOfPoints.ToString()}");
    }

    public void AddDeltaTime(Vector3 positionVarita)
    {
        if(!_isMoveVarita) return;
        //_deltaTimeLocal += Time.deltaTime;
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