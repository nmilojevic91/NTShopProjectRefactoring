
using TheShop.Model;

namespace TheShop.BuisnessLogic.Interfaces
{
	public interface IShopService
	{
		void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId);
		Article GetById(int id);
	}
}
