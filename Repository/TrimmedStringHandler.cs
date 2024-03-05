﻿using Dapper;
using System.Data;

namespace Legajos.Repository
{
    public class TrimmedStringHandler: SqlMapper.TypeHandler<string>
    {
        public override string Parse(object value)
        {
            string result = (value as string)?.Trim();
            return result;
        }
        public override void SetValue(IDbDataParameter parameter, string value)
        {
            parameter.Value = value;
        }
    }
}
