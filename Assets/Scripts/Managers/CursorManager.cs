using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The manager of cursor moving and mouse click events.
/// </summary>
public class CursorManager : Singleton<CursorManager>
{

    /// <summary>
    /// The current cursor position in world space.
    /// </summary>
    public Vector2 CursorPosition => Camera.main.ScreenToWorldPoint(Input.mousePosition);

    private Collider2D ColliderAtCursorPosition => Physics2D.OverlapPoint(CursorPosition);


    private void Update()
    {
        // Get collider as a local variable.
        Collider2D colliderAtCursorPosition = ColliderAtCursorPosition;

        // Call OnMouseClicked method if collider has clickable components. 
        if (colliderAtCursorPosition && Input.GetMouseButtonDown(0))
        {
            IMouseClickable clickable = colliderAtCursorPosition.GetComponent<IMouseClickable>();
            clickable?.OnMouseClicked();
        }
    }

}


/// <summary>
/// The interface of all components act when clicked.
/// </summary>
public interface IMouseClickable
{
    /// <summary>
    /// This method is call when clicked.
    /// </summary>
    public void OnMouseClicked();
}
