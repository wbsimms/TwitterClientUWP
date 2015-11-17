using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace TwitterClient.ViewModel
{
	public class ViewModelLocator
	{
		static UnityContainer container = new UnityContainer();


		/// <summary>
		/// Initializes a new instance of the ViewModelLocator class.
		/// </summary>
		public ViewModelLocator()
		{
			container.RegisterType<MainViewModel>(new ContainerControlledLifetimeManager());
			ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
		}

		public MainViewModel Main
		{
			get
			{
				return ServiceLocator.Current.GetInstance<MainViewModel>();
			}
		}

		public static void Cleanup()
		{
			// TODO Clear the ViewModels
		}
	}

}
