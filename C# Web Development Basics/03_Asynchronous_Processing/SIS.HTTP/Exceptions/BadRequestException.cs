using System;
using SIS.HTTP.Common;

namespace SIS.HTTP.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base(GlobalConstants.BadRequestMessage)
        {
            
        }
    }
}
