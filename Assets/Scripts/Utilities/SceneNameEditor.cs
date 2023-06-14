using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Draws scene selector of SceneName strings.
/// </summary>
[CustomPropertyDrawer(typeof(SceneName))]
public class SceneNameEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        _scenes = GetSceneNames();
        SceneName sceneName = attribute as SceneName;
        string cntString = (string)fieldInfo.GetValue(property.serializedObject.targetObject);

        sceneName.Selected = 0;
        sceneName.Name = _scenes[0].text;

        // Get from last value.
        for (int i = 0; i < _scenes.Length; i++)
        {
            if (_scenes[i].text == cntString)
            {
                sceneName.Selected = i;
                sceneName.Name = cntString;
                break;
            }
        }

        // Set new value.
        sceneName.Selected = EditorGUI.Popup(position, label, sceneName.Selected, _scenes);
        sceneName.Name = _scenes[sceneName.Selected].text;
        fieldInfo.SetValue(property.serializedObject.targetObject, sceneName.Name);

        if (GUI.changed)
        {
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        }
    }

    /// <summary>
    /// Get all scenes in build settings.
    /// </summary>
    /// <returns>An array of all scenes</returns>
    private GUIContent[] GetSceneNames()
    {
        GUIContent[] g = new GUIContent[EditorBuildSettings.scenes.Length];
        for (int i = 0; i < g.Length; i++)
        {
            string[] splitRes = EditorBuildSettings.scenes[i].path.Split('/');
            string nameWithSuffix = splitRes[splitRes.Length - 1];
            g[i] = new GUIContent(nameWithSuffix.Substring(0, nameWithSuffix.Length - ".unity".Length));
        }
        return g;
    }

    private GUIContent[] _scenes;
}
