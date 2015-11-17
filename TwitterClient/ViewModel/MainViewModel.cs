using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight;

namespace TwitterClient.ViewModel
{
	public class MainViewModel : ViewModelBase
	{
		private DispatcherTimer timer = new DispatcherTimer();
		TweetHelper helper = new TweetHelper();

		public MainViewModel()
		{
			TweetList = helper.GetTweets();
			timer.Interval = new TimeSpan(0,0,15);
			timer.Tick += (sender, o) => 
			{
				TweetList = helper.GetTweets();
			};
			timer.Start();
		}

		public const string TweetListPropertyName = "TweetList";
		private List<Tweet> tweetList = new List<Tweet>();

		public List<Tweet> TweetList
		{
			get { return this.tweetList; }
			set
			{
				if (tweetList == value)
				{
					return;
				}
				tweetList = value;
				RaisePropertyChanged(TweetListPropertyName);
			}
		}

	}
}
