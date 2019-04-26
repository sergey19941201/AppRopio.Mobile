// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AppRopio.Base.Auth.iOS.Views.SignUp.Cells
{
    [Register ("SignUpItemBaseViewCell")]
    partial class SignUpItemBaseViewCell
    {
        [Outlet]
        AppRopio.Base.iOS.Controls.ARTextField _textField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_textField != null) {
                _textField.Dispose ();
                _textField = null;
            }
        }
    }
}