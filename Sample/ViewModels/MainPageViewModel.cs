using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Reactive.Bindings;
using Xamarin.Forms;

namespace Sample.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigationAware
	{
        public ReactiveProperty<bool> EffectOn { get; } = new ReactiveProperty<bool>(false);
        public ReactiveProperty<string> CommandParameterText { get; } = new ReactiveProperty<string>();

        public ReactiveCommand<string> EffectCommand { get; } = new ReactiveCommand<string>();

        public MainPageViewModel()
		{
            EffectCommand.Subscribe(p=>{
                CommandParameterText.Value = p;
            });
		}




		public void OnNavigatedFrom(NavigationParameters parameters)
		{

		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
            EffectOn.Value = true;
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
		}
	}
}

