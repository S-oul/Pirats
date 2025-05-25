using ShipHelpers;
using UnityEngine;
public class Enemies : MonoBehaviour
{
    [SerializeField] private Transform whereToAttack;
    [SerializeField] private bool isLeft = true;
    public bool goAttack = false;
    

    private float boatSpeedIncrease = .5f;
    // Update is called once per frame
    void Update()
    {
        if (goAttack)
        {
            transform.position = Vector3.Lerp(transform.position,whereToAttack.position,Time.deltaTime * boatSpeedIncrease);
            boatSpeedIncrease += Time.deltaTime/10f;
            bool isCanonloaded = isLeft ? GameManager.Instance.Ship.CanonLeft.isLoaded : GameManager.Instance.Ship.CanonRight.isLoaded;
            if (isCanonloaded && Vector3.Distance(transform.position, whereToAttack.position) < 8f)
            {
                boatSpeedIncrease = 0;
                if (isLeft) GameManager.Instance.Ship.CanonLeft.Shoot();
                else GameManager.Instance.Ship.CanonRight.Shoot();
                goAttack = false; 
            }
            else if (!isCanonloaded) GameManager.Instance.Ship.ShipStateMachine.GoNextState();
        }
    }
}
