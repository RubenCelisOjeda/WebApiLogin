using ApiLogin.Application.Dto.Auth.ExistsCodeEmail.Request;
using ApiLogin.Application.Dto.Auth.ExistsEmail.Request;
using ApiLogin.Application.Dto.Auth.SendCodeEmail.Request;
using ApiLogin.DDD.Transversal.Common;
using ApiLogin.DDD.Transversal.Utils;
using ApiLogin.Domain.Entities.RecoveryPassword.Request.ExistsCodeEmail;
using ApiLogin.Domain.Entities.RecoveryPassword.Request.SendCodeEmail;
using ApiLogin.Domain.Repository;
using ApiLogin.Infraestructure.Dapper.ExternalService.Smtp.Email;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace ApiLogin.Application.Services.RecoveryPassword
{
    public class RecoveryPasswordService : IRecoveryPasswordService
    {
        #region [Variables]
        private readonly ILogger<RecoveryPasswordService> _logger;
        private readonly IMapper _mapper;
        private readonly IRecoveryPasswordRepository _recoveryPasswordRepository;
        private readonly IGenericRepository _genericRepository;
        private readonly IEmailService _emailService;
        #endregion

        #region [Constructor]
        public RecoveryPasswordService(ILogger<RecoveryPasswordService> logger, IMapper mapper, IRecoveryPasswordRepository recoveryPasswordRepository, IGenericRepository genericRepository, IEmailService emailService)
        {
            _logger = logger;
            _mapper = mapper;
            _recoveryPasswordRepository = recoveryPasswordRepository;
            _genericRepository = genericRepository;
            _emailService = emailService;
        }
        #endregion

        #region [Methods]
        public async Task<BaseResponse<bool>> SendCodeEmail(SendCodeEmailRequestDto request)
        {
            BaseResponse<bool> baseResponse = null;

            try
            {
                #region [1. Validations]
                var isValid = MetGlo.IsEmail(request.Email);
                if (!isValid)
                {
                    baseResponse = BaseResponse<bool>.BaseResponseWarning(false, $"El el email {request.Email} ingresado es invalido.");
                    return baseResponse;
                }

                var existsEmail = await _genericRepository.Exists("Usuarios", "Email", request.Email);
                if (!existsEmail)
                {
                    baseResponse = BaseResponse<bool>.BaseResponseWarning(false, $"No existe el email {request.Email} ingresado.");
                    return baseResponse;
                }
                #endregion

                //1 mapper request
                var mapperRequest = _mapper.Map<SendCodeEmailRequestEntities>(request);

                //2 response
                var response = await _emailService.SendCodeEmail(MetGlo.CodeGeneratedRandom());

                if (response)
                    baseResponse = BaseResponse<bool>.BaseResponseSuccess(response);
                else
                    baseResponse = BaseResponse<bool>.BaseResponseWarning(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                baseResponse = BaseResponse<bool>.BaseResponseError(ex.Message);
            }
            return baseResponse;
        }

        public async Task<BaseResponse<bool>> ExistsCodeEmail(ExistsCodeEmailRequestDto request)
        {
            BaseResponse<bool> baseResponse = null;

            try
            {
                //1 mapper request
                var mapperRequest = _mapper.Map<ExistsCodeEmailRequestEntities>(request);

                //2 response
                var response = await _genericRepository.Exists("Sessions", "CodeGenereted", request.CodeGenerated);

                //3 mapper response
                var mapperResponse = _mapper.Map<bool>(response);

                if (response)
                    baseResponse = BaseResponse<bool>.BaseResponseSuccess(mapperResponse, Constant.ResponseMessage.CodeValid);
                else
                    baseResponse = BaseResponse<bool>.BaseResponseWarning(mapperResponse,Constant.ResponseMessage.CodeNoValid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                baseResponse = BaseResponse<bool>.BaseResponseError(ex.Message);
            }
            return baseResponse;
        }

        public async Task<BaseResponse<bool>> ExistsEmail(ExistsEmailRequestDto request)
        {
            BaseResponse<bool> baseResponse = null;

            try
            {
                ////1 mapper request
                //var mapperRequest = _mapper.Map<GetAllUserRequestEntities>(request);

                ////2 response
                //var response = await _recoveryPasswordRepository.ExistsEmail(mapperRequest);

                ////3 mapper response
                //var mapperResponse = _mapper.Map<bool>(response);

                //if (response.Count() > 0)
                //    baseResponse = BaseResponse<bool>.BaseResponseSuccess(mapperResponse);
                //else
                //    baseResponse = BaseResponse<bool>.BaseResponseWarning(mapperResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                baseResponse = BaseResponse<bool>.BaseResponseError(ex.Message);
            }
            return baseResponse;
        }
        #endregion
    }
}
