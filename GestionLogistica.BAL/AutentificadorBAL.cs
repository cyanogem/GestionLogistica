using GestionLogistica.Abstraction.DTO;
using GestionLogistica.Abstraction;
using GestionLogistica.Services;
using Microsoft.Extensions.Logging;
using GestionLogistica.Entity.DTO;

namespace GestionLogistica.BAL
{
    public class AutentificadorBAL
    {
        ILogger logger;
        ITokenHandlerService _tokenService;
        public AutentificadorBAL(ILogger<AutentificadorBAL> logger, ITokenHandlerService tservice)
        {
            this.logger = logger;
            _tokenService = tservice;
        }

        public ResponseServicesDTO verifiedAuth(UserLoginRequestDTO user)
        {

            ResponseServicesDTO response = new ResponseServicesDTO();
            //TODO: Llamar el componente de seguridad en particular la Autenticacion
            bool usuarioExiste = true;
            if (usuarioExiste)
            {
                TokenParameters tokenparameters = new TokenParameters();
                tokenparameters.Id = "1";
                tokenparameters.UserName = user.Email;
                tokenparameters.PasswordHash = user.Password;

                var jwtToken = _tokenService.GenerateJWTToken(tokenparameters);

                UserLoginResponseDTO userresponse = new UserLoginResponseDTO();
                userresponse.Success = true;
                userresponse.Token = jwtToken;
                userresponse.UserId = 1;
                userresponse.UserName = user.Email;
                userresponse.PrimerApellido = "Jairo";
                userresponse.PrimerNombre = "Sanabria";


                this.logger.LogInformation("Usuario Autenticado !!!");

                response = createResponse(
                userresponse,
                true,
                (int)1,//Codificar mensajes de respuestas , crear clase 
                getResponseMessage(),
                0);
            }
            return response;
        }


        public ResponseServicesDTO createResponse(Object? objectResponse, bool success, int codeServiceResponse, string? descriptionServiceResponse, int CountRegisters)
        {
            return new ResponseServicesDTO()
            {
                ObjectResponse = objectResponse,
                Success = success,
                CodeServiceResponse = codeServiceResponse,
                DescriptionServiceResponse = descriptionServiceResponse,
                CountRegisters = CountRegisters
            };
        }


        public string? getResponseMessage()
        {
            string mesagge = "Satisfactorio";
            return mesagge;
        }
    }
}