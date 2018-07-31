using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace SortNSearch
{
    //TODO: find better name
    public static class PropertyManager
    {
        public static string GetMemberName(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentException("Expression cannot be null");
            }

            if (expression is MemberExpression)
            {
                // Reference type property or field
                var memberExpression = (MemberExpression)expression;
                return memberExpression.Member.Name;
            }

            if (expression is MethodCallExpression)
            {
                // Reference type method
                var methodCallExpression = (MethodCallExpression)expression;
                return methodCallExpression.Method.Name;
            }

            if (expression is UnaryExpression)
            {
                // Property, field of method returning value type
                var unaryExpression = (UnaryExpression)expression;
                return GetMemberName(unaryExpression);
            }

            throw new ArgumentException("Invalid Expression");
        }
        public static TResult GetMemberValue<TObject, TResult>(TObject obj, string memberName)
        {
            var type = obj.GetType();

            var info = type.GetProperty(memberName);
            if (info == null) { return default(TResult) ; }

            return (TResult)info.GetValue(obj, null);
        }
    }
}
