using System;
using TheShop.DataAccess;
using TheShop.Model;
using TheShop.Utilities;

namespace TheShop
{
	public class ShopService
	{
		private DatabaseDriver DatabaseDriver;
		private Logger logger;

		private Supplier1 Supplier1;
		private Supplier2 Supplier2;
		private Supplier3 Supplier3;
		
		public ShopService()
		{
			DatabaseDriver = new DatabaseDriver();
			logger = new Logger();
			Supplier1 = new Supplier1();
			Supplier2 = new Supplier2();
			Supplier3 = new Supplier3();
		}

		public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
		{
			// ordering article
			ISupplier[] suppliers = new ISupplier[]
			{
				Supplier1, Supplier2, Supplier3
			};
			Article article = FindArticle(id, maxExpectedPrice, suppliers);

			if (article == null)
			{
				throw new Exception("Could not order article");
			}

			//selling article
			SellArticle(article,buyerId);

		}
		/// <summary>
		/// Checks if any of the suppliers has Article in specified price range in stock
		/// </summary>
		/// <param name="id">Id of the article</param>
		/// <param name="maxExpectedPrice">Max price of the Article</param>
		/// <param name="suppliers">List of suppliers available</param>
		/// <param name="index">recursion index</param>
		/// <returns>Article if found, null if not existing</returns>
		private Article FindArticle(int id, int maxExpectedPrice, ISupplier[] suppliers, int index = 0)
		{
			if(suppliers.Length == index)
			{
				logger.Debug("No more suppliers to check");
				return null;
			}

			ISupplier supplier = suppliers[index];

			logger.Debug($"Checking supplier [Name = {supplier.ToString()}]");
			var articleExists = supplier.ArticleInInventory(id);
			if (articleExists)
			{
				Article tempArticle = supplier.GetArticle(id);
				if(maxExpectedPrice >= tempArticle.ArticlePrice)
				{
					return tempArticle;
				}
			}

			logger.Debug($"Supplier [Name = {supplier.ToString()}]: Article not found, searching at another supplier");

			return FindArticle(id, maxExpectedPrice, suppliers, index + 1);
		}

		/// <summary>
		/// Tries to sell the article
		/// </summary>
		/// <param name="article">Article to sell</param>
		/// <param name="buyerId">Id of the Buyer</param>
		private void SellArticle(Article article, int buyerId)
		{ 
			if(article == null)
			{
				logger.Debug("Article not found. Aborting selling of article");
				return;
			}
			logger.Debug("Trying to sell article with id=" + article.ID);

			article.IsSold = true;
			article.SoldDate = DateTime.Now;
			article.BuyerUserId = buyerId;

			try
			{
				DatabaseDriver.Save(article);
				logger.Info("Article with id=" + article.ID + " is sold.");
			}
			catch (ArgumentNullException ex)
			{
				logger.Error("Could not save article with id=" + article.ID);
				throw new Exception("Could not save article with id");
			}
			catch (Exception)
			{
			}
		}
		public Article GetById(int id)
		{
			return DatabaseDriver.GetById(id);
		}
	}
}
