using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;

public class WaitingLine : MonoBehaviour
{
    public List<PiratController> _availablePirats = new List<PiratController>();
    
    public List<Transform> _queuePos = new List<Transform>();

    public bool AssignTask(Task task)
    {
        if (_availablePirats.Count > 0)
        {
            _availablePirats[0].PiratGhost.SetDestination(task.GhostTransform.position);
            _availablePirats[0].GetComponent<GoToTask>().Task = task;
            _availablePirats[0].MyStateMachine.GoNextState();
            _availablePirats.RemoveAt(0);
            return true;
        }else return false;
    }

    public Transform GetNextLinePosition()
    {
        return _queuePos[_availablePirats.Count];
    }
}
