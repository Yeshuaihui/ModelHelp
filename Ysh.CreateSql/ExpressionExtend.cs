using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ysh.CreateSql
{
    public static class ExpressionExtend
    {
        //操作符转换
        public static string TransferOperand(this ExpressionType type,string method="")
        {
            string operand = string.Empty;
            switch (type)
            {
                case ExpressionType.AndAlso:
                    operand = "AND";
                    break;
                case ExpressionType.OrElse:
                    operand = "OR";
                    break;
                case ExpressionType.Equal:
                    operand = "=";
                    break;
                case ExpressionType.NotEqual:
                    operand = "<>";
                    break;
                case ExpressionType.LessThan:
                    operand = "<";
                    break;
                case ExpressionType.LessThanOrEqual:
                    operand = "<=";
                    break;
                case ExpressionType.GreaterThan:
                    operand = ">";
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    operand = ">=";
                    break;
                case ExpressionType.Call:
                    switch (method)
                    {
                        case "Contains":
                            operand = "in";
                            break;
                    }
                    break;
            }
            return operand;
        }
    }
}
