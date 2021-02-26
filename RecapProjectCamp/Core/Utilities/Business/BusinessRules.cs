using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logicx in logics)
            {
                if (!logicx.Success)
                {
                    return logicx;
                }
            }

            return null;
        }
    }
}
