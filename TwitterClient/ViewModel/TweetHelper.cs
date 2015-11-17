using System.Collections.Generic;
using System.Linq;
using LinqToTwitter;

namespace TwitterClient.ViewModel
{
	public class TweetHelper
	{
		private SingleUserAuthorizer auth = new SingleUserAuthorizer()
		{
			CredentialStore = new SingleUserInMemoryCredentialStore()
			{
				ConsumerKey = "Fill in",
				ConsumerSecret = "Fill in",
				OAuthToken = "Fill in",
				OAuthTokenSecret = "Fill in",
				ScreenName = "Your twitter user name"
			}
		};

		TwitterContext twitterContext;
		public TweetHelper()
		{
			Init();

		}

		public void Init()
		{
			auth.AuthorizeAsync().Wait();
			twitterContext = new TwitterContext(auth);
		}

		public List<Tweet> GetTweets()
		{
			var tweets = twitterContext.Status.Where(x => x.Type == StatusType.Home).ToList();
			return tweets.Select(x => new Tweet()
			{
				TweetMeesage = x.Text,
				User = x.User.Name,
				ImageUrl = x.Entities.MediaEntities.Count > 0 ? x.Entities.MediaEntities.First().MediaUrl : ""
			}).ToList();
		}
	}
}