using System;
using NUnit.Framework;
using TheShop;

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
			Exception thrownException = null;
			//act
			try
			{
				service.OrderAndSellArticle(id, maxPrice, buyerId);
			}
			catch(Exception e)
			{
				thrownException = e;
			}
			//assert
			Assert.IsNull(thrownException);
		}

		[TestCase(2, 100, 10)]
		[TestCase(4, 20, 13)]
		[TestCase(-1, 20, 14)]
		[TestCase(3, -50, 12)]
		public void TestOrderAndSellArticleNonExistingArticle(int id, int maxPrice, int buyerId)
		{
			//prepare 
			ShopService service = new ShopService();
			Exception thrownException = null;
			string message = "";

			//act
			try
			{
				service.OrderAndSellArticle(id, maxPrice, buyerId);
			}
			catch (Exception e)
			{
				thrownException = e;
				message = e.Message;
			}

			//assert
			Assert.IsNotNull(thrownException);
			Assert.AreEqual(message, "Could not order article");
		}

		[TestCase(1, 1, 10)]
		public void TestTooExpensive(int id, int maxPrice, int buyerId)
		{
			//prepare 
			ShopService service = new ShopService();
			Exception thrownException = null;
			string message = "";

			//act
			try
			{
				service.OrderAndSellArticle(id, maxPrice, buyerId);
			}
			catch (Exception e)
			{
				thrownException = e;
				message = e.Message;
			}

			//assert
			Assert.IsNotNull(thrownException);
			Assert.AreEqual(message, "Could not order article");
		}
	}
}
