
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

using System.Collections;
using System.Collections.Generic;

[RealtimeModel]
public partial class PedestalActivatorModel 
{
    // so the issue I was left with here is to understand what are the 'primitives'
    // that Normal accepts to compile into realtime components
    // I was trying with material and then transform first to get access 
    // to switching the material of the activator in a networked way
    
    [RealtimeProperty(1, false, true)]
    //private GameObject _gameObject;
    
    // private Transform _transform;
    
   // private Material _material;

    private Color _color;

    
}



/* ----- Begin Normal Autogenerated Code ----- */
public partial class PedestalActivatorModel : RealtimeModel {
    public UnityEngine.Color color {
        get {
            return _colorProperty.value;
        }
        set {
            if (_colorProperty.value == value) return;
            _colorProperty.value = value;
            InvalidateReliableLength();
            FireColorDidChange(value);
        }
    }
    
    public delegate void PropertyChangedHandler<in T>(PedestalActivatorModel model, T value);
    public event PropertyChangedHandler<UnityEngine.Color> colorDidChange;
    
    public enum PropertyID : uint {
        Color = 1,
    }
    
    #region Properties
    
    private ReliableProperty<UnityEngine.Color> _colorProperty;
    
    #endregion
    
    public PedestalActivatorModel() : base(null) {
        _colorProperty = new ReliableProperty<UnityEngine.Color>(1, _color);
    }
    
    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        _colorProperty.UnsubscribeCallback();
    }
    
    private void FireColorDidChange(UnityEngine.Color value) {
        try {
            colorDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = 0;
        length += _colorProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        var writes = false;
        writes |= _colorProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case (uint) PropertyID.Color: {
                    changed = _colorProperty.Read(stream, context);
                    if (changed) FireColorDidChange(color);
                    break;
                }
                default: {
                    stream.SkipProperty();
                    break;
                }
            }
            anyPropertiesChanged |= changed;
        }
        if (anyPropertiesChanged) {
            UpdateBackingFields();
        }
    }
    
    private void UpdateBackingFields() {
        _color = color;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */
