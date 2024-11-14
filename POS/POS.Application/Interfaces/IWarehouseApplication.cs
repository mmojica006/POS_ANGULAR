using POS.Application.Commons.Bases.Request;
using POS.Application.Commons.Bases.Response;
using POS.Application.Dtos.Warehouse.Response;

namespace POS.Application.Interfaces
{
    public interface IWarehouseApplication
    {
        Task<BaseResponse<IEnumerable<WarehouseResponseDto>>> ListWarehouses(BaseFilterRequest filters);
        Task<BaseResponse<WarehouseByIdResponseDto>> WarehousesById(int warehouseId);
    }
}
