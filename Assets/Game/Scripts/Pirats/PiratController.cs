using UnityEngine;

public class PiratController : MonoBehaviour
{
    [SerializeField] PiratGhostController _piratGhost;
    
    public PiratGhostController PiratGhost
    {
        get => _piratGhost;
    }
}
