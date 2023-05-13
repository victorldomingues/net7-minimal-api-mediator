using System.Diagnostics.CodeAnalysis;
using MediatR;

namespace TodoApi.Extensions;

public static class EndpointHandlerExtension
{
    public static RouteHandlerBuilder MapPost<TRequest>(this IEndpointRouteBuilder endpoints,
        [StringSyntax("Route")] string pattern) where TRequest : notnull
            => endpoints.MapPost(pattern, SendAsync<TRequest>());


    public static RouteHandlerBuilder MapGet<TRequest>(this IEndpointRouteBuilder endpoints,
        [StringSyntax("Route")] string pattern) where TRequest : notnull
            => endpoints.MapPost(pattern, SendAsync<TRequest>());


    public static RouteHandlerBuilder MapPut<TRequest>(this IEndpointRouteBuilder endpoints, 
        [StringSyntax("Route")] string pattern) where TRequest : notnull
            => endpoints.MapPut(pattern, SendAsync<TRequest>());
    

    public static RouteHandlerBuilder MapDelete<TRequest>(this IEndpointRouteBuilder endpoints, 
        [StringSyntax("Route")] string pattern) where TRequest : notnull
            =>endpoints.MapDelete(pattern, SendAsync<TRequest>());
    

    public static Delegate SendAsync<TRequest>() where TRequest : notnull
        => async (IMediator mediator, [AsParameters] TRequest request)
            => await mediator.Send(request);
    

}
