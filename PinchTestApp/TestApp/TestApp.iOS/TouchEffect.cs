using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

//[assembly: ResolutionGroupName("new")]
//[assembly: ExportEffect(typeof(TestApp.iOS.TouchEffect), "new1")]
namespace TestApp.iOS
{
    //public class TouchEffect : PlatformEffect
    //{
    //    UIView view;
    //    TouchRecognizer touchRecognizer;

    //    protected override void OnAttached()
    //    {
    //        // Get the iOS UIView corresponding to the Element that the effect is attached to
    //        view = Control == null ? Container : Control;

    //        // Get access to the TouchEffect class in the PCL
    //        TestApp.ViewModel.TouchEffect effect = (TestApp.ViewModel.TouchEffect)Element.Effects.FirstOrDefault(e => e is TestApp.ViewModel.TouchEffect);

    //        if (effect != null && view != null)
    //        {
    //            // Create a TouchRecognizer for this UIView
    //            touchRecognizer = new TouchRecognizer(Element, view, effect);
    //            view.AddGestureRecognizer(touchRecognizer);
    //        }
    //    }

    //    protected override void OnDetached()
    //    {
    //        if (touchRecognizer != null)
    //        {
    //            // Clean up the TouchRecognizer object
    //            touchRecognizer.Detach();

    //            // Remove the TouchRecognizer from the UIView
    //            view.RemoveGestureRecognizer(touchRecognizer);
    //        }
    //    }
    //}
}