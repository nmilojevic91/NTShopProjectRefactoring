using System;
using NUnit.Framework;
using TheShop;
using TheShop.Model;

namespace TheShopUnitTests
{
	public class OrderAndSellArticleTests
	{
		[TestCase(1, 100000, 10)]
		[TestCase(1, 100000, 10)]
		[TestCase(1, 10000, 12)]
		[TestCase(1, 100000, 13)]
		[TestCase(1, 100000, 14)]
		public void TestOrderAndSellArticleSuccess(int id, int maxPrice, int buyerId)
		{
			//prepare 

			ShopService service = new ShopService();
			//act
			bool success = service.OrderAndSellArticle(id, maxPrice, buyerId);

			//assert
			Assert.IsTrue(success);
		}

		[TestCase(2, 100, 10)]
		[TestCase(4, 20, 13)]
		[TestCase(-1, 20, 14)]
		[TestCase(3, -50, 12)]
		public void TestOrderAndSellArticleNonExistingArticle(int id, int maxPrice, int buyerId)
		{
			//prepare 
			ShopService service = new ShopService();

			//act
			bool success = service.OrderAndSellArticle(id, maxPrice, buyerId);
			
			//assert
			Assert.IsFalse(success);
		}

		[TestCase(1, 1, 10)]
		public void TestTooExpensive(int id, int maxPrice, int buyerId)
		{
			//prepare 
			ShopService service = new ShopService();

			//act
			bool success = service.OrderAndSellArticle(id, maxPrice, buyerId);


			//assert
			Assert.IsFalse(success);
		}

		[TestCase(1, 1000, 10)]
		public void TestSuccesfullySoldArticle(int id, int maxPrice, int buyerId)
		{
			//prepare 
			ShopService service = new ShopService();
			Article article = null;

			//act
			bool success = service.OrderAndSellArticle(id, maxPrice, buyerId);
			article = service.GetById(id);
			
			//assert
			Assert.IsTrue(success);
			Assert.IsNotNull(article);
		}
	}
}
