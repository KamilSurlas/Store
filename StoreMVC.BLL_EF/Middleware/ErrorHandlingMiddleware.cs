using Microsoft.AspNetCore.Http;
using StoreMVC.BLL_EF.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMVC.BLL_EF.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next.Invoke(context);
			}
			catch (ContentNotFoundException ex)
			{
				context.Response.StatusCode = 404;
				await context.Response.WriteAsync(ex.Message);			
			}
			catch(InvalidAmountException ex)
			{
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (InvalidDataException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (InvalidPriceException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (Exception)
            {            
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Ups, something went wrong");
            }
        }
    }
}
