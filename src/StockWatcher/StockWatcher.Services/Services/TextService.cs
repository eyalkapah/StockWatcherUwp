using StockWatcher.Services.Interfaces;
using System;

namespace StockWatcher.Services.Services
{
    public class TextService: ITextService
    {
        public void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }
}
