using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public sealed class RepositoryManager : IRepositoryManager
	{
		private readonly Lazy<IProductionApplication> _productionApplicationRepository;
		private readonly Lazy<IProductRepository> _productRepository;
		private readonly Lazy<IBoxRepository> _boxRepository;
		private readonly Lazy<ICategoryRepository> _categoryRepository;
		private readonly Lazy<IInvoiceRepository> _invoiceRepository;
		private readonly Lazy<IPalletRepository> _palletRepository;
		private readonly Lazy<IProductUnitRepository> _productUnitRepository;

		public RepositoryManager(AppDbContext appDbContext)
		{
			_productionApplicationRepository = new Lazy<IProductionApplication>(() => new ProductionApplicationRepository(appDbContext));
			_productRepository = new Lazy<IProductRepository>(() => new ProductRepository(appDbContext));
			_boxRepository = new Lazy<IBoxRepository>(() => new BoxRepository(appDbContext));
			_categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(appDbContext));
			_invoiceRepository = new Lazy<IInvoiceRepository>(() => new InvoiceRepository(appDbContext));
			_palletRepository = new Lazy<IPalletRepository>(() => new PalletRepository(appDbContext));
			_productUnitRepository = new Lazy<IProductUnitRepository>(() => new ProductUnitRepository(appDbContext));
		}

		public IProductRepository ProductRepository => _productRepository.Value;

		public IProductionApplication ProductionApplication => _productionApplicationRepository.Value;

		public IBoxRepository BoxRepository => _boxRepository.Value;

		public ICategoryRepository CategoryRepository => _categoryRepository.Value;

		public IInvoiceRepository InvoiceRepository => _invoiceRepository.Value;

		public IPalletRepository PalletRepository => _palletRepository.Value;

		public IProductUnitRepository ProductUnitRepository => _productUnitRepository.Value;
	}
}
