using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.Common;

public class PhoneNumber
{
    public string Number
    {
        get;
        init;
    }
    private PhoneNumber(string phoneNumber)
    {

    }

    public static Result<PhoneNumber> Create(string number)
    {
        if(Regex.Match(number, "+7[0-9]{11}").Success == false)
        {
            return Result.Failure<PhoneNumber>(new Error("1", "Not match"));
        }
        return Result.Sucsesfull(new PhoneNumber(number)); 
    }

}
