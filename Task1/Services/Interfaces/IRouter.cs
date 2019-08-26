using System;
using Task1.Controllers.Interfaces;

namespace Task1.Services.Interfaces
{
    public interface IRouter
    {
        IController GetController(int[] args);
        IController GetErrorController(Exception ex);
    }
}
