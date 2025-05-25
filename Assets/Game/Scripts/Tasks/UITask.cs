using System;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UITask : MonoBehaviour
{
    [ShowNonSerializedField] private Task _task;
    
    string _taskName;
    string _timeTaskTakes;
    
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _timeText;
    private Button _assignButton;
    private Slider _slider;
    private Image _bgImage;
    
    //I Know animator for UI are not the best, but it's not important for this Test 
    private Animator _animator;

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
    public Slider Slider { get => _slider; set => _slider = value; }
    public Animator Animator { get => _animator; set => _animator = value; }

    public Button AssignButton
    {
        get => _assignButton;
        set => _assignButton = value;
    }

    public Image BgImage
    {
        get => _bgImage;
        set => _bgImage = value;
    }

    #endregion

    private void Awake()
    {
        AssignButton = GetComponentInChildren<Button>();
        AssignButton.onClick.AddListener(SendTaskToPirat);
        _slider = GetComponent<Slider>();
        _animator = GetComponent<Animator>();
        _bgImage = GetComponentInChildren<Image>();
    }

    private void SendTaskToPirat()
    {
        AssignButton.interactable = !GameManager.Instance.Line.TryAssignTask(_task);
    }
    
       
        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void SetScaleToOne()
        {
            GetComponent<RectTransform>().localScale = Vector3.one;
            _assignButton.interactable = true;

        }
}
