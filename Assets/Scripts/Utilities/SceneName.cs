using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Requires a string must be the name of a scene.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public class SceneName : PropertyAttribute
{
    /// <summary>
    /// The name of the selected scene.
    /// </summary>
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    /// <summary>
    /// The selected index.
    /// </summary>
    public int Selected
    {
        get => _selected;
        set => _selected = value;
    }

    private string _name;
    private int _selected;
}
