using MuhasebeAPI.Application.DTOs;
using MuhasebeAPI.Domain.Entities;
using MuhasebeAPI.Domain.Interfaces;
namespace MuhasebeAPI.Infrastructure.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IStockRepository _stockRepository;
        private readonly ICompanyRepository _companyRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository, IStockRepository stockRepository, ICompanyRepository companyRepository)
        {
            _invoiceRepository = invoiceRepository;
            _stockRepository = stockRepository;
            _companyRepository = companyRepository;
        }

        public async Task<Invoice> CreateInvoiceAsync(InvoiceDto dto, Guid userId)
        {
            var company = await _companyRepository.GetByIdAsync(dto.CompanyId);
            if (company == null)
                throw new Exception("Company not found.");

            if (company.UserId != userId)
                throw new UnauthorizedAccessException("You are not authorized to create invoices for this company.");

            var invoice = new Invoice
            {
                CompanyId = dto.CompanyId,
                AccountId = dto.AccountId,
                InvoiceType = dto.InvoiceType,
                InvoiceDate = dto.InvoiceDate,
                CreatedAt = DateTime.UtcNow,
                InvoiceItems = new List<InvoiceItem>()
            };

            decimal totalAmount = 0;

            foreach (var itemDto in dto.Items)
            {
                var stock = await _stockRepository.GetByIdAsync(itemDto.StockId);
                if (stock == null)
                    throw new Exception($"Stock with ID {itemDto.StockId} not found.");

                // Stok güncellemesi
                if (dto.InvoiceType.Equals("Purchase", StringComparison.OrdinalIgnoreCase))
                {
                    if (stock.Quantity < itemDto.Quantity)
                        throw new Exception($"Insufficient stock for item ID {itemDto.StockId}.");

                    stock.Quantity -= itemDto.Quantity;
                }
                else if (dto.InvoiceType.Equals("Sales", StringComparison.OrdinalIgnoreCase))
                {
                    stock.Quantity += itemDto.Quantity;
                }
                else
                {
                    throw new Exception("Invalid invoice type. Use 'Sales' or 'Purchase'.");
                }

                var invoiceItem = new InvoiceItem
                {
                    StockId = itemDto.StockId,
                    Quantity = itemDto.Quantity,
                    UnitPrice = itemDto.UnitPrice,
                    CreatedAt = DateTime.UtcNow
                };

                invoice.InvoiceItems.Add(invoiceItem);
                totalAmount += itemDto.Quantity * itemDto.UnitPrice;
            }

            invoice.TotalAmount = totalAmount;

            await _invoiceRepository.AddAsync(invoice);
            await _stockRepository.SaveChangesAsync();  // Stok güncellemelerini kaydet
            await _invoiceRepository.SaveChangesAsync(); // Faturayı kaydet

            return invoice;
        }

        public async Task<Invoice?> GetByIdWithDetailsAsync(Guid id)
        {
            return await _invoiceRepository.GetByIdWithDetailsAsync(id);
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await _invoiceRepository.GetAllAsync();
        }

        /*public async Task UpdateInvoiceAsync(Guid id, InvoiceUpdateDto dto)
        {
            var invoice = await _invoiceRepository.GetByIdWithDetailsAsync(id);
            if (invoice == null)
                throw new Exception("Invoice not found.");

            // Basitçe güncelleme örneği, detaylı implementasyon gerektirir
            invoice.InvoiceDate = dto.InvoiceDate;

            // Burada eski stokları eski miktar kadar geri ekleme, yeni stokları düşme/girme işlemi yapılmalı

            // Örneğin, önce eski InvoiceItems ile stokları geri ekle, sonra yeni itemlerle stokları güncelle

            // Detaylı mantık için ayrıca yazılabilir

            await _invoiceRepository.SaveChangesAsync();
        }*/

        public async Task DeleteInvoiceAsync(Guid id)
        {
            var invoice = await _invoiceRepository.GetByIdWithDetailsAsync(id);
            if (invoice == null)
                throw new Exception("Invoice not found.");

            // Stokları geri ekleme işlemi gerekebilir
            if (invoice.InvoiceType.Equals("cikis", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var item in invoice.InvoiceItems)
                {
                    var stock = await _stockRepository.GetByIdAsync(item.StockId);
                    if (stock != null)
                    {
                        stock.Quantity += item.Quantity; // stok geri eklenir
                    }
                }
                await _stockRepository.SaveChangesAsync();
            }
            else if (invoice.InvoiceType.Equals("giris", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var item in invoice.InvoiceItems)
                {
                    var stock = await _stockRepository.GetByIdAsync(item.StockId);
                    if (stock != null)
                    {
                        stock.Quantity -= item.Quantity; // stok çıkarılır
                        if (stock.Quantity < 0) stock.Quantity = 0; // negatif olmaz
                    }
                }
                await _stockRepository.SaveChangesAsync();
            }

            _invoiceRepository.Delete(invoice);
            await _invoiceRepository.SaveChangesAsync();
        }
    }
}
