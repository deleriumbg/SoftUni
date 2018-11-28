using System;
using SIS.HTTP.Common;

namespace SIS.HTTP.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException() : base(GlobalConstants.InternalServerErrorMessage)
        {
            
        }
    }
}
