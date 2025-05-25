using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _textScore; 
    void Update()
    {
        _textScore.text = "Distance : " + (int)GameManager.Instance.Ship.transform.position.x;
    }
}
