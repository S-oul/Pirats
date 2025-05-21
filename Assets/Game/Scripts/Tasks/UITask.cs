using System;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UITask : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [ShowNonSerializedField] private Task _task;
    
    string _taskName;
    string _timeTaskTakes;
    
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _timeText;
    private Button _assignButton; 
    
    #region Accessor
    public string Title
    {
        get => _taskName;
        set
        {
            _taskName = value;
            _titleText.text = _taskName; 
        }
    }
    public string TimeTaskTakes
    {
        get => _timeTaskTakes;
        set
        {
            _timeTaskTakes = value;
            _timeText.text = _timeTaskTakes;   
        }
    }

    public Task MyTask
    {
        get => _task;
        set => _task = value;
    }

    #endregion

    private void Awake()
    {
        _assignButton = GetComponentInChildren<Button>();
        _assignButton.onClick.AddListener(SendTaskToGameManager);
    }

    private void SendTaskToGameManager()
    {
        GameManager.Instance.AssignTask(_task);
    }
    

    #region UI

    

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Set parent as "BG" (Horizontal Layout Group)
        transform.parent = transform.parent.GetChild(0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Set parent as Canvas
        transform.parent = transform.parent.parent;
    }
    #endregion
}
