using System;
using Task1_Board.Controllers.Interfaces;

namespace Task1_Board.Services.Interfaces
{
    public interface IRouter
    {
        Controller GetController(int[] args);
        Controller GetErrorController(Exception ex);
    }
}
