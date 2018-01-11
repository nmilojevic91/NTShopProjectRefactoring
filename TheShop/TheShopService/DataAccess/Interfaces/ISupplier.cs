using TheShop.Model;

namespace TheShop.DataAccess
{
    interface ISupplier
    {
		Article GetArticle(int id);
		bool ArticleInInventory(int id);
	}
}
