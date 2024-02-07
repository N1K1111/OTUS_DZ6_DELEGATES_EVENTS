using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTUS_DZ6_DELEGATES_EVENTS
{
    public static class Foo
    {
        public static Func<object, float> func;
        public static void Work()
        {
            IEnumerable<CustomElement> f = new List<CustomElement>() { new CustomElement() { Value = 4},
                new CustomElement() { Value = 7}, new CustomElement() { Value = -22} };

            func += GetParameter;

            var max = f.GetMax(func);
        }

        public static float GetParameter<T>(T data) where T : class
        {
            if (data is CustomElement)
            {
                var val = data.GetType().GetProperties().First().GetValue(data);

                return float.Parse(val.ToString());
            }
            return 0.0f;
        }


        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection.Count() == 0)
            {
                return null;
            }

            T max = collection.First();

            foreach (T item in collection) 
            {
                var res = convertToNumber(item);

                if (convertToNumber.Invoke(max) < res)
                {
                    max = item;
                }
            }
            return max;
        }

        public class CustomElement
        {
            public int Value { get; set; }
        }
    }
}
