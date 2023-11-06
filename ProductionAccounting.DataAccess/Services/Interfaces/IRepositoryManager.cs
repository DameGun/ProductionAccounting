namespace ProductionAccounting.DataAccess.Services.Interfaces
{
    public interface IRepositoryManager
    {
        IProductRepository ProductRepository { get; }
        IProductionApplication ProductionApplication { get; }
        IBoxRepository BoxRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IPalletRepository PalletRepository { get; }
        IProductUnitRepository ProductUnitRepository { get; }
    }
}
