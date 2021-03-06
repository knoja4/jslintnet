﻿namespace JSLintNet.Json
{
    using System.Collections.Generic;
    using JSLintNet.Models;
    using JSLintNet.Settings;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Provides JSON related services.
    /// </summary>
    internal class JsonProvider : IJsonProvider
    {
        /// <summary>
        /// The serializer settings.
        /// </summary>
        private static JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented,
            Error = OnError,
            Converters = new List<JsonConverter>()
            {
                new StringEnumConverter(),
                new JSLintErrorConverter(),
                new JSLintFunctionConverter()
            }
        };

        /// <summary>
        /// Deserializes the data.
        /// </summary>
        /// <param name="value">The serialized value.</param>
        /// <returns>
        /// A new <see cref="IJSLintData" /> instance.
        /// </returns>
        public IJSLintData DeserializeData(string value)
        {
            return JsonConvert.DeserializeObject<JSLintData>(value, serializerSettings);
        }

        /// <summary>
        /// Deserializes the settings.
        /// </summary>
        /// <param name="value">The serialized value.</param>
        /// <returns>
        /// A new <see cref="JSLintNetSettings" /> instance.
        /// </returns>
        public JSLintNetSettings DeserializeSettings(string value)
        {
            return JsonConvert.DeserializeObject<JSLintNetSettings>(value, serializerSettings);
        }

        /// <summary>
        /// Serializes the options.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// A serialized string.
        /// </returns>
        public string SerializeOptions(JSLintOptions value)
        {
            return JsonConvert.SerializeObject(value, serializerSettings);
        }

        /// <summary>
        /// Serializes the settings.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// A serialized string.
        /// </returns>
        public string SerializeSettings(JSLintNetSettings value)
        {
            return JsonConvert.SerializeObject(value, serializerSettings);
        }

        /// <summary>
        /// Called when a JSON error occurs.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ErrorEventArgs"/> instance containing the event data.</param>
        /// <remarks>Prevents exceptions bubbling up to the consumer.</remarks>
        private static void OnError(object sender, ErrorEventArgs e)
        {
            e.ErrorContext.Handled = true;
        }
    }
}
