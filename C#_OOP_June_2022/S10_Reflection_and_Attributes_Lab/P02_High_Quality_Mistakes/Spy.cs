namespace Stealer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {

        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {

            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            var sb = new StringBuilder();

            object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static| BindingFlags.Public);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            var sb = new StringBuilder();


            foreach (FieldInfo field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have be public!");
            }
            foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have be private!");
            }

            return sb.ToString().Trim();

        }
    }
}
