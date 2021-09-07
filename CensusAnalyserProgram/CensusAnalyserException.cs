using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProgram
{
    public class CensusAnalyserException:Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE,INCORRECT_DELIMETER,INCORRECR_HEADER,NO_SUCH_COUNTRY
        }

        public ExceptionType exType;

        public CensusAnalyserException(string message,ExceptionType exceptionType) : base(message)
        {
            this.exType = exceptionType;
        }

    }
}
