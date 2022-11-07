using System;
using System.Collections.Generic;
using System.Reflection;

namespace VeiculosApp.Core.Domain.Mapping
{
    public abstract class BaseMapping<TInput, TOutput>
        where TInput : new()
        where TOutput : new()
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        public static implicit operator TOutput(BaseMapping<TInput, TOutput> value)
        {
            var newOutput = new TOutput();

            var propertiesInput = typeof(TInput).GetProperties();
            var propertiesOutput = typeof(TOutput).GetProperties();

            RunThroughtObject(propertiesInput, propertiesOutput, newOutput, value);

            return newOutput;
        }
        private static void RunThroughtObject(IEnumerable<PropertyInfo> propertiesInput, IEnumerable<PropertyInfo> propertiesOutput, TOutput output, BaseMapping<TInput, TOutput> value)
        {
            foreach (var inputP in propertiesInput)
            {
                foreach (var outputP in propertiesOutput)
                {
                    if (inputP.Name == outputP.Name)
                    {
                        if (outputP.GetType().IsClass
                            && inputP.GetType().IsClass
                            && !outputP.GetType().IsPrimitive
                            && !inputP.GetType().IsPrimitive)
                        {
                            var propertiesI = inputP.GetType().GetProperties();
                            var propertiesO = outputP.GetType().GetProperties();
                            RunThroughtObject(propertiesI, propertiesO, output, value);
                        }
                        else if (inputP.PropertyType == outputP.PropertyType)
                        {
                            outputP.SetValue(output, inputP.GetValue(value));
                        }
                    }
                }
            }
        }
    }
}
