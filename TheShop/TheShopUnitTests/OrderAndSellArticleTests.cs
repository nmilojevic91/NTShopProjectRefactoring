using System;
using NUnit.Framework;
using TheShop;

namespace TheShopUnitTests
{
	public class OrderAndSellArticleTests
	{
		[TestCase(1, 20, 10)]
		[TestCase(1, 100, 10)]
		[TestCase(1, -50, 12)]
		[TestCase(1, 20, 13)]
		[TestCase(1, 20, 14)]
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
		[TestCase(3, -50, 12)]
		[TestCase(4, 20, 13)]
		[TestCase(-1, 20, 14)]
		public void TestOrderAndSellArticleNonExistingArticle(int id, int maxPrice, int buyerId)
		{
			//prepare 
			ShopService service = new ShopService();
			Exception thrownException = null;

			//act
			try
			{
				service.OrderAndSellArticle(id, maxPrice, buyerId);
			}
			catch (Exception e)
			{
				thrownException = e;
			}

			//assert
			Assert.IsNull(thrownException);
		}

		[TestCase(1, 1, 10)]
		public void TestTooExpensive(int id, int maxPrice, int buyerId)
		{
			//prepare 
			ShopService service = new ShopService();
			Exception thrownException = null;

			//act
			try
			{
				service.OrderAndSellArticle(id, maxPrice, buyerId);
			}
			catch (Exception e)
			{
				thrownException = e;
			}

			//assert
			Assert.IsNull(thrownException);
		}
	}
}
