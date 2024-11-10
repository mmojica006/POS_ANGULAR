using AutoMapper;
using POS.Application.Commons.Bases;
using POS.Application.Dtos.Category.Response;
using POS.Application.Dtos.Provider.Response;
using POS.Application.Interfaces;
using POS.Application.Validators.Category;
using POS.Infrastructure.Commons.Bases.Request;
using POS.Infrastructure.Commons.Bases.Response;
using POS.Infrastructure.Persistences.Interfaces;
using POS.Utilities.Static;

namespace POS.Application.Services
{
    public class ProviderApplication : IProviderApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly ProviderValidator _validationRules;

        public ProviderApplication(IUnitOfWork unitOfWork, IMapper mapper, CategoryValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_validationRules = validationRules;
        }
        public async Task<BaseResponse<BaseEntityResponse<ProviderResponseDto>>> ListProviders(BaseFilterRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<ProviderResponseDto>>();
            var providers = await _unitOfWork.Provider.ListProviders(filters);

            if (providers is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<ProviderResponseDto>>(providers);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }
    }
}
