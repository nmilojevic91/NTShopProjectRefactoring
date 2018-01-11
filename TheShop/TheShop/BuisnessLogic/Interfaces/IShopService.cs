
using TheShop.Model;

namespace TheShop.BuisnessLogic.Interfaces
{
	public interface IShopService
	{
		bool OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId);
		Article GetById(int id);
	}
}
