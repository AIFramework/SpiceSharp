using System;
using System.Text.RegularExpressions;
using SpiceSharp.Circuits;
using SpiceSharp.Components;

namespace SpiceSimulation
{
    /// <summary>
    /// Создание модели диода
    /// </summary>
    public class DiodCreator
    {
        public DiodeModel CreateDiodeModel(string name, string parameters)
        {
            var dm = new DiodeModel(name);
            ApplyParameters(dm, parameters);
            return dm;
        }

        protected void ApplyParameters(Entity entity, string definition)
        {
            // Get all assignments
            definition = Regex.Replace(definition, @"\s*\=\s*", "=");
            var assignments = definition.Split(new[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var assignment in assignments)
            {
                // Get the name and value
                var parts = assignment.Split('=');
                if (parts.Length != 2)
                    throw new Exception("Invalid assignment");
                var name = parts[0].ToLower();
                var value = double.Parse(parts[1], System.Globalization.CultureInfo.InvariantCulture);

                // Set the entity parameter
                entity.SetParameter(name, value);
            }
        }
    }

    
}