using POS.Application.Commons.Bases.Request;
using POS.Application.Commons.Bases.Response;
using POS.Application.Dtos.Warehouse.Request;
using POS.Application.Dtos.Warehouse.Response;

namespace POS.Application.Interfaces
{
    public interface IWarehouseApplication
    {
        Task<BaseResponse<IEnumerable<WarehouseResponseDto>>> ListWarehouses(BaseFilterRequest filters);
        Task<BaseResponse<WarehouseByIdResponseDto>> WarehousesById(int warehouseId);
        Task<BaseResponse<bool>> Registerwarehouse(WarehouseRequestDto requestDto);
        Task<BaseResponse<bool>> EditWarehouse(int warehouseId, WarehouseRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveWarehouse(int warehouseId);
    }
}
