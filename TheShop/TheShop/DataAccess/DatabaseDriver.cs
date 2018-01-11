using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Model;
using TheShop.Utilities;
using TheShop.Utilities.Interfaces;

namespace TheShop.DataAccess
{
	public class DatabaseDriver
	{
		private ILogger logger = new ConsoleLogger();
		private List<Article> _articles = new List<Article>();

		public Article GetById(int id)
		{
			if (_articles != null && _articles.Any(x => x.ID == id))
			{
				return _articles.Single(x => x.ID == id);
			}
			return null;
		}

		public bool Save(Article article)
		{
			try
			{
				if (_articles != null && article != null)
				{
					_articles.Add(article);
				}
				else
				{
					logger.Info("Couldn't save article. Article not available or database not initiated");
				}
			}
			catch (Exception e)
			{
				logger.Error("Unexpected exception upon saving article:" + e);
				return false;
			}
			return true;
		}
	}
}
