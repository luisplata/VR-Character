using UnityEngine;

public class HandActionsCustom : BellsebossHand
{
    [Header("Name of Hand")] 
    [SerializeField] private HandName _handName;
    
    [Header("Stick")]
    [SerializeField] private ButtonTouchActionCustom gridTouch;
    [SerializeField] private ButtonPressActionCustom gridPress;
    [SerializeField] private ReadVector2 grid;
    
    [Header("Triggers")]
    [SerializeField] private ButtonTouchActionCustom trigger;
    [SerializeField] private ButtonPressActionCustom triggerPress;
    [SerializeField] private ReadLine triggerLine;
    
    [Header("Catch")]
    [SerializeField] private ButtonPressActionCustom catchPress;
    [SerializeField] private ReadLine catchLine;

    [Header("Primary Button")] 
    [SerializeField] private ButtonTouchActionCustom primaryButtonTouch;
    [SerializeField] private ButtonPressActionCustom primaryButtonPress;

    [Header("Second Button")] 
    [SerializeField] private ButtonTouchActionCustom secondButtonTouch;
    [SerializeField] private ButtonPressActionCustom secondButtonPress;
    
    //private vars to hand facade
    
    //Grid
    private bool _gridIsTouch = false;
    private bool _gridIsPress = false;
    private Vector2 _gridVector = Vector2.zero;
    
    //primary button
    private bool _primaryButtonTouch = false;
    private bool _primaryButtonPress = false;
    
    //Secondary button
    private bool _secondButtonTouch = false;
    private bool _secondButtonPress = false;

    //trigger
    private bool _triggerTouch = false;
    private bool _triggerPress = false;
    private float _triggerLine = 0f;
    
    //catch
    private bool _catchPress = false;
    private float _catchLine = 0f;
    private IBodyAction _body;

    public void Configurate(IBodyAction body)
    {
        _body = body;
    }

    //End private vars
    private void Start()
    {
        secondButtonPress.IsPress += b =>
        {
            _secondButtonPress = b;
        };
        secondButtonTouch.IsTouch += b =>
        {
            _secondButtonTouch = b;
        };
        catchLine.Line += f =>
        {
            _catchLine = f;
        };
        catchPress.IsPress += b =>
        {
            _catchPress = b;
        };
        trigger.IsTouch += b =>
        {
            _triggerTouch = b;
        };
        triggerPress.IsPress += b =>
        {
            _triggerPress = b;
        };
        triggerLine.Line += f =>
        {
            _triggerLine = f;
        };
        gridTouch.IsTouch += b =>
        {
            _gridIsTouch = b;
        };
        gridPress.IsPress += b =>
        {
            _gridIsPress = b;
        };
        grid.Vector += vector2 =>
        {
            _gridVector = vector2;
        };
        primaryButtonPress.IsPress += b =>
        {
            _primaryButtonPress = b;
        };
        primaryButtonTouch.IsTouch += b =>
        {
            _primaryButtonTouch = b;
        };
    }
    
    //Publicate Method
    public HandName GetHand()
    {
        return _handName;
    }
    public bool PrimaryButtonPress()
    {
        return _primaryButtonPress;
    }

    public bool PrimaryButtonTouch()
    {
        return _primaryButtonTouch;
    }

    public bool SecondButtonTouch()
    {
        return _secondButtonTouch;
    }

    public bool SecondButtonPress()
    {
        return _secondButtonPress;
    }

    public bool CatchPress()
    {
        return _catchPress;
    }

    public float CatchValue()
    {
        return _catchLine;
    }

    public Vector2 GetStick()
    {
        return _gridVector;
    }

    public bool StickPress()
    {
        return _gridIsTouch;
    }

    public bool StickTouch()
    {
        return _gridIsPress;
    }

    public bool TriggerPress()
    {
        return _triggerPress;
    }

    public bool TriggerTouch()
    {
        return _triggerTouch;
    }

    public float TriggerValue()
    {
        return _triggerLine;
    }

    public IBodyAction GetBody()
    {
        return _body;
    }
}

public enum HandName
{
    LEFT,
    RIGHT
}