using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

public class ColorSerializationSurrogate : ISerializationSurrogate
{
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        Color color = (Color)obj;
        info.AddValue("a", color.a);
        info.AddValue("r", color.r);
        info.AddValue("g", color.g);
        info.AddValue("b", color.b);
    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
    {
        Color color = (Color)obj;
        color.a = (float)info.GetValue("a", typeof(float));
        color.r = (float)info.GetValue("r", typeof(float));
        color.g = (float)info.GetValue("g", typeof(float));
        color.b = (float)info.GetValue("b", typeof(float));
        obj = color;
        return obj;
    }

}
