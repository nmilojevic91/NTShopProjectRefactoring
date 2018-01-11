using System;
using TheShop;

namespace TheShopClient
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			try
			{
				var shopService = new ShopService();
				//order and sell
				shopService.OrderAndSellArticle(1, 20, 10);

				tryBuyArticle(shopService, 1);
				tryBuyArticle(shopService, 12);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			
			Console.ReadKey();
		}

		private static void tryBuyArticle(ShopService shopService, int id)
		{
			//print article on console				
			var article = shopService.GetById(id);
			if (article != null)
			{
				Console.WriteLine("Found article with ID: " + id);
			}
			else
			{
				Console.WriteLine("Could not save article with ID: " + id);
			}
		}
	}
}