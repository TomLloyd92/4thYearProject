using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class HandButton : XRBaseInteractable
{

    //Check Press and Previous press
    public UnityEvent OnPress = null;
    private bool previousPress = false;

    //Min Max of the Y Pos
    private float YpushMin = 0;
    private float YpushMax = 0;

    //The hand Interactor
    private XRBaseInteractor handInteractor = null;
    //Hands Y
    float previousYAxisHeight= 0;

    //Overide for awake
    protected override void Awake()
    {
        //Set up Everything as usual
        base.Awake();
        //AddListeners for start and end press
        onHoverEntered.AddListener(StartPress);
        onHoverExited.AddListener(EndPress);

    }

    private void OnDestroy()
    {
        //Remove Listeners when destroyed
        onHoverEntered.RemoveListener(StartPress);
        onHoverExited.RemoveListener(EndPress);
    }

    private void StartPress(XRBaseInteractor interactorHand)
    {
        
        handInteractor = interactorHand;
        //Get Y position of the hand relative to the object
        previousYAxisHeight = GetYPos(handInteractor.transform.position);

    }

    private void EndPress(XRBaseInteractor interactorHand)
    {
        //Release the hand Interactor
        handInteractor = null;
        //Reset the y Pos
        previousYAxisHeight = 0;

        previousPress = false;
        SetYPos(YpushMax);
    }

    private void Start()
    {
        SetMinMax();
    }

    private void SetMinMax()
    {
        //Get this collider
        Collider collider = GetComponent<Collider>();

        //Get the minimum and maximum positions relative to colider
        YpushMin = (transform.localPosition.y) - ((collider.bounds.size.y)  /2) ;
        YpushMax = transform.localPosition.y;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if(handInteractor)
        {
            //Get previous hand heigh, new hand height and the difference
            float newHandHeight = GetYPos(handInteractor.transform.position);
            float handDifference = previousYAxisHeight - newHandHeight;
            previousYAxisHeight = newHandHeight;

            //Set the new position of Y
            float newPosition = transform.localPosition.y - handDifference;
            SetYPos(newPosition);

            //Check updated hand pressing
            checkPress();
        }    

        base.ProcessInteractable(updatePhase);
    }

    private float GetYPos(Vector3 t_Pos)
    {
        //Convert to local space
        Vector3 localPos = transform.root.InverseTransformPoint(t_Pos);

        return localPos.y;
    }

    private void SetYPos(float t_yPos)
    {
        Vector3 newPos = transform.localPosition;
        newPos.y = Mathf.Clamp(t_yPos, YpushMin, YpushMax);
        transform.localPosition = newPos;

    }

    private void checkPress()
    {
        //Check if hand is in possition
        bool inPossition = inPos();

        if(inPossition && inPossition != previousPress)
        {
            OnPress.Invoke();
        }
        previousPress = inPossition;
    }

    private bool inPos()
    {
        //Is the Hand close enough
        float inRange = Mathf.Clamp(transform.localPosition.y, YpushMin, YpushMin + 0.01f);

        return transform.localPosition.y == inRange;
    }
    

}
