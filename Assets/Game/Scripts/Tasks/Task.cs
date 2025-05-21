using UnityEngine;
using UnityEngine.EventSystems;

public class Task : MonoBehaviour
{
    bool taskNeedsToBeDone = false;

    float timeBeforeTaskIsFail = 10f;


    public virtual void onEndTask()
    {
        taskNeedsToBeDone = false;
    }
    public void OnTaskFailed()
    {
        
    }
    public void OnTaskSuccess()
    {
        
    }

   
}
