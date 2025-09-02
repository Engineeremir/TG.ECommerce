using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TG.ECommerce.Shared.SeedWork;

namespace TG.ECommerce.Application.SeedWork.PipelineBehaviours
{
    public class ExceptionPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<ExceptionPipelineBehaviour<TRequest, TResponse>> _logger;

        public ExceptionPipelineBehaviour(ILogger<ExceptionPipelineBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (DomainException)
            {
                throw;
            }
            catch (ApplicationGeneralException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UndefinedApplicationException(ex.Message, ex);
            }
        }
    }

}
