using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace QuickEye.DarkTheme
{
    public class Toolbar : VisualElement
    {
        private static readonly StyleSheet _ToolbarDarkStyleSheet;
        public static readonly string ussClassName = "unity-toolbar";

        static Toolbar()
        {
            _ToolbarDarkStyleSheet = Resources.Load<StyleSheet>("com.quickeye.dark-runtime-theme/Toolbar Dark");
        }

        public Toolbar()
        {
            AddToClassList(ussClassName);
            SetToolbarStyleSheet(this);
        }


        public new class UxmlFactory : UxmlFactory<Toolbar>
        {
        }

        public static void SetToolbarStyleSheet(VisualElement ve)
        {
            ve.styleSheets.Add(_ToolbarDarkStyleSheet);
        }
    }

    public class ToolbarToggle : Toggle
    {
        public new static readonly string ussClassName = "unity-toolbar-toggle";

        public ToolbarToggle()
        {
            focusable = false;

            Toolbar.SetToolbarStyleSheet(this);
            RemoveFromClassList(Toggle.ussClassName);
            AddToClassList(ussClassName);
        }

        public new class UxmlFactory : UxmlFactory<ToolbarToggle, UxmlTraits>
        {
        }

        public new class UxmlTraits : Toggle.UxmlTraits
        {
        }
    }

    public class ToolbarButton : Button
    {
        public new static readonly string ussClassName = "unity-toolbar-button";

        public ToolbarButton(Action clickEvent) : base(clickEvent)
        {
            Toolbar.SetToolbarStyleSheet(this);
            RemoveFromClassList(Button.ussClassName);
            AddToClassList(ussClassName);
        }

        public ToolbarButton() : this(() => { })
        {
        }

        public new class UxmlFactory : UxmlFactory<ToolbarButton, UxmlTraits>
        {
        }

        public new class UxmlTraits : Button.UxmlTraits
        {
        }
    }
}