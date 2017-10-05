using System;
using Sample;
using Sample.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.Diagnostics;

[assembly: ResolutionGroupName("AiForms")]
[assembly: ExportEffect(typeof(EfPlatformEffect), nameof(Ef))]
namespace Sample.Droid
{
    
    public class EfPlatformEffect:PlatformEffect
    {
        Android.Views.View _view;

        protected override void OnAttached()
        {
            _view = Control ?? Container;
            var renderer = (Container ?? Control) as IVisualElementRenderer;
            Debug.WriteLine($"Element:{renderer?.Element} / Tracker:{renderer?.Tracker}");
            //Debug.WriteLine($"{Element.GetType().Name}\t{Control?.GetType().Name}\t{Container?.GetType().Name}");

            //_view.Touch += _view_Touch;
            if(Element is ListView || Element is TableView){
                return;
            }

            _view.Click += _view_Click;
        }

        void _view_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            if(e.Event.Action == Android.Views.MotionEventActions.Up){
                var cmd = Ef.GetCommand(Element);
                var param = Ef.GetCommandParameter(Element);

                cmd?.Execute(param);

                Debug.WriteLine($"{Element.GetType().Name} is touched.");
            }
        }

        void _view_Click(object sender, EventArgs e)
        {
            var cmd = Ef.GetCommand(Element);
            var param = Ef.GetCommandParameter(Element);

            cmd?.Execute(param);

            Debug.WriteLine($"{Element.GetType().Name} is clicked.");
        }

        protected override void OnDetached()
        {
            var renderer = (Container ?? Control) as IVisualElementRenderer;
            if (renderer?.Tracker != null)
            {    // Check disposed
                
            }
            Debug.WriteLine($"Element:{renderer?.Element} / Tracker:{renderer?.Tracker}");
        }
    }
}
