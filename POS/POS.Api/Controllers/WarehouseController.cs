using Microsoft.AspNetCore.Mvc;
using POS.Application.Commons.Bases.Request;
using POS.Application.Dtos.Warehouse.Request;
using POS.Application.Interfaces;
using POS.Utilities.Static;

namespace POS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseApplication _warehouseApplication;
        private readonly IGenerateExcelApplication _generateExcelApplication;

        public WarehouseController(IWarehouseApplication warehouseApplication, IGenerateExcelApplication generateExcelApplication)
        {
            _warehouseApplication = warehouseApplication;
            _generateExcelApplication = generateExcelApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ListWarehouses([FromQuery] BaseFilterRequest filters)
        {
            var response = await _warehouseApplication.ListWarehouses(filters);

            if ((bool)filters.Download!)
            {
                var columnNames = ExcelColumnNames.GetColumnsWarehouses();
                var fileBytes = _generateExcelApplication.GenerateToExcel(response.Data!, columnNames);
                return File(fileBytes, ContentType.ContentTypeExcel);
            }

            return Ok(response);
        }

        [HttpGet("{warehouseId:int}")]
        public async Task<IActionResult> WarehouseById(int warehouseId)
        {
            var response = await _warehouseApplication.WarehousesById(warehouseId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterWarehouse([FromBody] WarehouseRequestDto requestDto)
        {
            var response = await _warehouseApplication.Registerwarehouse(requestDto);
            return Ok(response);
        }
    }
}
