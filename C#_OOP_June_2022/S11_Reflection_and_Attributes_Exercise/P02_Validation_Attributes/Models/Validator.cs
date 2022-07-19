namespace ValidationAttributes.Models
{
    using System.Reflection;
    public static class Validator
    {

        public static bool IsValid(object obj)
        {

            PropertyInfo[] properties = obj
                .GetType()
                .GetProperties();

            foreach (PropertyInfo property in properties)
            {

                var customAtributute = 
                    (MyValidationAttribute)property
                    .GetCustomAttribute(typeof(MyValidationAttribute));


                var valid = customAtributute.IsValid(property.GetValue(obj));

                if (!valid)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
