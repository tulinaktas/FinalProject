using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        //message ve succes var ayrica data var
        T Data { get; }
    }
}
