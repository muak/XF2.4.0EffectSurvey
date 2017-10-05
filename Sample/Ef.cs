using System;
using System.Linq;
using Xamarin.Forms;
using System.Windows.Input;

namespace Sample
{
    public static class Ef
    {
        public static readonly BindableProperty OnProperty =
            BindableProperty.CreateAttached(
                    "On",
                    typeof(bool),
                    typeof(Ef),
                    default(bool),
                    propertyChanged: OnOffChanged
                );

        public static void SetOn(BindableObject view, bool value)
        {
            view.SetValue(OnProperty, value);
        }

        public static bool GetOn(BindableObject view)
        {
            return (bool)view.GetValue(OnProperty);
        }

        static void OnOffChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;
            if (view == null)
                return;

            if ((bool)newValue)
            {
                view.Effects.Add(new EfRoutingEffect());
            }
            else
            {
                var toRemove = view.Effects.FirstOrDefault(e => e is EfRoutingEffect);
                if (toRemove != null)
                    view.Effects.Remove(toRemove);
            }
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.CreateAttached(
                    "Command",
                    typeof(ICommand),
                    typeof(Ef),
                    default(ICommand)
                );

        public static void SetCommand(BindableObject view, ICommand value)
        {
            view.SetValue(CommandProperty, value);
        }

        public static ICommand GetCommand(BindableObject view)
        {
            return (ICommand)view.GetValue(CommandProperty);
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.CreateAttached(
                    "CommandParameter",
                    typeof(object),
                typeof(Ef),
                    default(object)
                );

        public static void SetCommandParameter(BindableObject view, object value)
        {
            view.SetValue(CommandParameterProperty, value);
        }

        public static object GetCommandParameter(BindableObject view)
        {
            return (object)view.GetValue(CommandParameterProperty);
        }

        class EfRoutingEffect : RoutingEffect
        {
            public EfRoutingEffect() : base("AiForms." + nameof(Ef)) { }
        }
    }
}
