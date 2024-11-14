using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using POS.Application.Commons.Bases.Request;
using POS.Application.Commons.Bases.Response;
using POS.Application.Commons.Ordering;
using POS.Application.Dtos.Category.Response;
using POS.Application.Dtos.Warehouse.Request;
using POS.Application.Dtos.Warehouse.Response;
using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Infrastructure.Persistences.Interfaces;
using POS.Utilities.Static;
using WatchDog;

namespace POS.Application.Services
{
    public class WarehouseApplication : IWarehouseApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderingQuery _orderingQuery;

        public WarehouseApplication(IUnitOfWork unitOfWork, IMapper mapper, IOrderingQuery orderingQuery)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderingQuery = orderingQuery;
        }
        public async Task<BaseResponse<IEnumerable<WarehouseResponseDto>>> ListWarehouses(BaseFilterRequest filters)
        {
            var response = new BaseResponse<IEnumerable<WarehouseResponseDto>>();
            try
            {
                var warehouses = _unitOfWork.Warehouse.GetAllQueryable();
                if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
                {
                    switch (filters.NumFilter)
                    {
                        case 1:
                            warehouses = warehouses.Where(x => x.Name!.Contains(filters.TextFilter));
                            break;
                    }
                }

                if (filters.StateFilter is not null)
                {
                    warehouses = warehouses.Where(x => x.State.Equals(filters.StateFilter));
                }

                if (!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
                {
                    warehouses = warehouses.Where(x => x.AuditCreateDate >= Convert.ToDateTime(filters.StartDate) && x.AuditCreateDate <= Convert.ToDateTime(filters.EndDate).AddDays(1));
                }

                if (filters.Sort is null) filters.Sort = "Id";
                var items = await _orderingQuery.Ordering(filters, warehouses, !(bool)filters.Download!).ToListAsync(); //Devuelve el resultado ordenado y paginado

                response.IsSuccess = true;
                response.TotalRecords = await warehouses.CountAsync();
                response.Data = _mapper.Map<IEnumerable<WarehouseResponseDto>>(items);
                response.Message = ReplyMessage.MESSAGE_QUERY;

                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }

      

        public async Task<BaseResponse<WarehouseByIdResponseDto>> WarehousesById(int warehouseId)
        {
            var response = new BaseResponse<WarehouseByIdResponseDto>();
            var warehouse = await _unitOfWork.Warehouse.GetByIdAsync(warehouseId);
            if (warehouse is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;

            }
            response.IsSuccess = true;
            response.Message = ReplyMessage.MESSAGE_QUERY;
            response.Data = _mapper.Map<WarehouseByIdResponseDto>(warehouse);
            response.Message = ReplyMessage.MESSAGE_QUERY;

            return response;
        }

        public async Task<BaseResponse<bool>> Registerwarehouse(WarehouseRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();

            using var transaction = _unitOfWork.BeginTransaction(); 
            try
            {
                var warehouse = _mapper.Map<Warehouse>(requestDto);
                response.Data = await _unitOfWork.Warehouse.RegisterAsync(warehouse);
                int warehouseId = warehouse.Id;

                var products = await _unitOfWork.Product.GetAllAsync();

                await RegisterProductStockByalmacen(products, warehouseId);


                transaction.Commit();
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;

            }
            catch (Exception ex) {
                transaction.Rollback();
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }

        private async Task RegisterProductStockByalmacen(IEnumerable<Product> products, int warehouseId)
        {
            foreach (var product in products) 
            {
                var newProductStock = new ProductStock
                {
                    ProductId = product.Id,
                    WarehouseId = warehouseId,
                    CurrentStock = 0,
                    PurchasePrice = 0,
                };

                await _unitOfWork.ProductStock.RegisterProductstock(newProductStock);
            }

        }
    }
}
