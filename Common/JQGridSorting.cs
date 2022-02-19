using HospitalManagementSystem.Common;
using HospitalManagementSystem.JqGrid;
using Newtonsoft.Json;
using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace VRMStackApp.Common
{
    public class JQGridSorting
    {

        public static Expression<Func<TEntity, bool>> GeneratePredicate<TEntity>(JQGridSort jQGridSort)
        {
            var predicate = PredicateBuilder.True<TEntity>();
            if (jQGridSort != null && !string.IsNullOrEmpty(jQGridSort.filters))

            {


                var tempFilters = JsonConvert.DeserializeObject<JQGridFilter>(jQGridSort.filters);
                //dynamic rules;
                //if (tempFilters.Groups != null)
                //{
                //    rules = tempFilters.Groups.rules;
                //}
                //else
                //{
                //    rules = tempFilters.rules;
                //}

                //foreach (var objfilterRule in tempFilters.)
                //{
                //    predicate = AddingFilter<TEntity>(predicate, objfilterRule);

                //}
                if (tempFilters.Groups != null)
                {
                    foreach (var objfilter in tempFilters.Groups)
                    {
                        var valule = string.Join(" ", objfilter.rules.Select(s => s.data));
                        var objrules = new Rule
                        {
                            data = valule,
                            field = objfilter.rules.Select(s => s.field).FirstOrDefault(),
                            op = objfilter.rules.Select(s => s.op).FirstOrDefault(),
                        };

                        predicate = AddingFilter<TEntity>(predicate, objrules);


                    }
                }

                foreach (var objfilterRule in tempFilters.rules)
                {
                    predicate = AddingFilter<TEntity>(predicate, objfilterRule);

                }


            }

            return predicate;
        }

        private static Expression<Func<TEntity, bool>> AddingFilter<TEntity>(Expression<Func<TEntity, bool>> predicate, dynamic objfilterRule)
        {
            if (!string.IsNullOrEmpty(objfilterRule.data) && !string.IsNullOrEmpty(objfilterRule.data))
            {

                var parameterExp = Expression.Parameter(typeof(TEntity), "type");
                var propertyExp = Expression.Property(parameterExp, objfilterRule.field);
                var filterType = Nullable.GetUnderlyingType((Type)propertyExp.Type) ?? (Type)propertyExp.Type;
                dynamic filterValue = ConvertTypeforFilterValue(filterType, objfilterRule.data);

                if (filterType == filterValue.GetType())
                {
                    var filterOperator = GetOperatorforFilterType(filterType, objfilterRule.data);
                    MethodInfo method = filterType.GetMethod(filterOperator, new[] { filterType });
                    if (method != null)
                    {
                        if (filterType == typeof(DateTime))
                        {
                            //var filterValueString = filterValue.ToString(AppConstant.DATEFORMATECOMPARE);
                            //var propertyExpDate = Expression.Property(parameterExp, objfilterRule.field + "String");
                            //var expConvert = Expression.Convert(propertyExpDate, typeof(string));
                            //ConstantExpression expValue = Expression.Constant(filterValueString, typeof(string));
                            //BinaryExpression body = Expression.Equal(expConvert, expValue);
                            //var isEqualExpressionTree = Expression.Lambda<Func<TEntity, bool>>(body, new[] { parameterExp });
                            //Expression<Func<TEntity, bool>> funcExpression = (Expression<Func<TEntity, bool>>)isEqualExpressionTree;
                            //predicate = predicate.And(funcExpression);


                            var ce = Expression.Convert(propertyExp, typeof(DateTime?));
                            ConstantExpression constant = Expression.Constant(filterValue.Date, typeof(DateTime?));
                            //MethodCallExpression mc = Expression.Call(typeof(EntityFunctions).GetMethod("TruncateTime", new Type[] { typeof(DateTime) }), ce);
                            MethodCallExpression mc = Expression.Call(typeof(EntityFunctions).GetMethod("TruncateTime", new Type[] { typeof(DateTime) }), ce);

                            BinaryExpression body = Expression.Equal(mc, constant);
                            var isEqualExpressionTree = Expression.Lambda<Func<TEntity, bool>>(body, new[] { parameterExp });
                            Expression<Func<TEntity, bool>> funcExpression = (Expression<Func<TEntity, bool>>)isEqualExpressionTree;
                            predicate = predicate.And(funcExpression);

                        }
                        else
                        {
                            var expValue = Expression.Constant(filterValue, filterType);
                            var expConvert = Expression.Convert(propertyExp, filterType);
                            var containsMethodExp = Expression.Call(expConvert, method, expValue);
                            Expression<Func<TEntity, bool>> dynamicpredicate = Expression.Lambda<Func<TEntity, bool>>(containsMethodExp, parameterExp);
                            predicate = predicate.And(dynamicpredicate);


                        }
                    }
                }


            }

            return predicate;
        }

        public static dynamic ConvertTypeforFilterValue(Type type, string value)
        {
            dynamic result;
            try
            {
                result = Convert.ChangeType(value, type);
            }
            catch (InvalidCastException)
            {
                result = false;
            }

            return result;

        }

        public static string GetOperatorforFilterType(Type type, dynamic data)
        {
            dynamic result = string.Empty;
            int isvalueType = default(int);
            if (type == typeof(int) || type == typeof(DateTime))
            {
                result = "Equals";
            }
            else
            {
                result = "Contains";
            }

            return result;
        }

    }
}
