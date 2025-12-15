using Domain.Entities;

namespace Domain.DomainServices
{
    public class ProductSumRates
	{
		private readonly Product _firstProduct;
		private readonly Product _secondProduct;

		public ProductSumRates(Product firstProduct, Product secondProduct)
		{
			_firstProduct = firstProduct;
			_secondProduct = secondProduct;
		}


		public  ProductSumRatesResult GetProductSumRates()
		{
			decimal sumProductsRate = _firstProduct.Rate + _secondProduct.Rate;

			ProductSumRatesResult productDescriptionResult = new ProductSumRatesResult();

			productDescriptionResult.TotalRates = sumProductsRate;
			productDescriptionResult.Products.Add(new ProductDescription { Id = _firstProduct.Id,Description = _firstProduct.Description });
			productDescriptionResult.Products.Add(new ProductDescription { Id = _secondProduct.Id, Description = _secondProduct.Description });

			return productDescriptionResult;
		}
	}
}
