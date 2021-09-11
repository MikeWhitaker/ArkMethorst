    namespace FlatRedBall.Gum
    {
        public  class GumIdbExtensions
        {
            public static void RegisterTypes () 
            {
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Circle", typeof(ArkMethorst.GumRuntimes.CircleRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("ColoredRectangle", typeof(ArkMethorst.GumRuntimes.ColoredRectangleRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Container", typeof(ArkMethorst.GumRuntimes.ContainerRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Container<T>", typeof(ArkMethorst.GumRuntimes.ContainerRuntime<>));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("NineSlice", typeof(ArkMethorst.GumRuntimes.NineSliceRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Polygon", typeof(ArkMethorst.GumRuntimes.PolygonRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Rectangle", typeof(ArkMethorst.GumRuntimes.RectangleRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Sprite", typeof(ArkMethorst.GumRuntimes.SpriteRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Text", typeof(ArkMethorst.GumRuntimes.TextRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/Button", typeof(ArkMethorst.GumRuntimes.DefaultForms.ButtonRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/CheckBox", typeof(ArkMethorst.GumRuntimes.DefaultForms.CheckBoxRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/ColoredFrame", typeof(ArkMethorst.GumRuntimes.DefaultForms.ColoredFrameRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/ComboBox", typeof(ArkMethorst.GumRuntimes.DefaultForms.ComboBoxRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/DialogBox", typeof(ArkMethorst.GumRuntimes.DefaultForms.DialogBoxRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/Keyboard", typeof(ArkMethorst.GumRuntimes.DefaultForms.KeyboardRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/KeyboardKey", typeof(ArkMethorst.GumRuntimes.DefaultForms.KeyboardKeyRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/Label", typeof(ArkMethorst.GumRuntimes.DefaultForms.LabelRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/ListBox", typeof(ArkMethorst.GumRuntimes.DefaultForms.ListBoxRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/ListBoxItem", typeof(ArkMethorst.GumRuntimes.DefaultForms.ListBoxItemRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/PasswordBox", typeof(ArkMethorst.GumRuntimes.DefaultForms.PasswordBoxRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/RadioButton", typeof(ArkMethorst.GumRuntimes.DefaultForms.RadioButtonRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/ScrollBar", typeof(ArkMethorst.GumRuntimes.DefaultForms.ScrollBarRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/ScrollBarThumb", typeof(ArkMethorst.GumRuntimes.DefaultForms.ScrollBarThumbRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/ScrollViewer", typeof(ArkMethorst.GumRuntimes.DefaultForms.ScrollViewerRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/Slider", typeof(ArkMethorst.GumRuntimes.DefaultForms.SliderRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/TextBox", typeof(ArkMethorst.GumRuntimes.DefaultForms.TextBoxRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/Toast", typeof(ArkMethorst.GumRuntimes.DefaultForms.ToastRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/ToggleButton", typeof(ArkMethorst.GumRuntimes.DefaultForms.ToggleButtonRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/TreeView", typeof(ArkMethorst.GumRuntimes.DefaultForms.TreeViewRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/TreeViewItem", typeof(ArkMethorst.GumRuntimes.DefaultForms.TreeViewItemRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/TreeViewToggleButton", typeof(ArkMethorst.GumRuntimes.DefaultForms.TreeViewToggleButtonRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/UserControl", typeof(ArkMethorst.GumRuntimes.DefaultForms.UserControlRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("GameScreenGum", typeof(ArkMethorst.GumRuntimes.GameScreenGumRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Level1Gum", typeof(ArkMethorst.GumRuntimes.Level1GumRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Level2Gum", typeof(ArkMethorst.GumRuntimes.Level2GumRuntime));
                
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.Button)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.ButtonRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.CheckBox)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.CheckBoxRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.ComboBox)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.ComboBoxRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.Games.DialogBox)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.DialogBoxRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.Games.OnScreenKeyboard)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.KeyboardRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.Label)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.LabelRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.ListBox)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.ListBoxRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.ListBoxItem)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.ListBoxItemRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.PasswordBox)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.PasswordBoxRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.RadioButton)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.RadioButtonRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.ScrollBar)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.ScrollBarRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.ScrollViewer)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.ScrollViewerRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.Slider)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.SliderRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.TextBox)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.TextBoxRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.Popups.Toast)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.ToastRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.ToggleButton)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.ToggleButtonRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.TreeView)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.TreeViewRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.TreeViewItem)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.TreeViewItemRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.UserControl)] = typeof(ArkMethorst.GumRuntimes.DefaultForms.UserControlRuntime);
            }
        }
    }
