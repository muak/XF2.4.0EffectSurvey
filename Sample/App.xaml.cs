﻿using Prism.Unity;
using Sample.Views;
using Xamarin.Forms;

namespace Sample
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();

			NavigationService.NavigateAsync("NavigationPage/ContentPage/MainPage");
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<ContentPage>();
            Container.RegisterTypeForNavigation<NavigationPage>();
		}
	}
}

